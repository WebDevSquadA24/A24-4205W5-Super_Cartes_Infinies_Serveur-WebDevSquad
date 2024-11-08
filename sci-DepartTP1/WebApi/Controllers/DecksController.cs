using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Claims;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DecksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private DecksService _decksService;

        public DecksController(ApplicationDbContext context, DecksService decksService)
        {
            _context = context;
            _decksService = decksService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Deck>> GetDecks()
        {
            var decks = _decksService.GetDecks(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            return Ok(decks);
        }

        [HttpGet("{deckId}")]
        public ActionResult<IEnumerable<Card>> GetDeckCards(int deckId)
        {
            var deck = _decksService.GetDeck(deckId);
            return deck == null ? NotFound() : Ok(deck.OwnedCards.Select(oc => oc.Card));
        }

        [Authorize]
        [HttpGet("{deckId}")]
        public ActionResult<IEnumerable<Card>> GetCardsNotInDeck(int deckId)
        {
            var cards = _decksService.GetCardsNotInDeck(deckId, User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            return cards == null ? NotFound() : Ok(cards.OrderBy(c => c.Name));
        }

        [HttpPost("{name}")]
        public ActionResult<Deck> Create(string name)
        {
            try
            {
                var deck = _decksService.Create(name, User.FindFirstValue(ClaimTypes.NameIdentifier)!);
                return Ok(deck);
            }
            catch (InvalidOperationException)
            {
                return BadRequest("The new deck is exceeding de number of deck allowed");
            }
            
        }

        [Authorize]
        [HttpDelete("{deckId}")]
        public IActionResult Delete(int deckId)
        {
            try
            {
                _decksService.Delete(deckId, User.FindFirstValue(ClaimTypes.NameIdentifier)!);
                return NoContent();
            } 
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("The deck does not belong to the player");
            }
            catch (InvalidOperationException)
            {
                return BadRequest("Cannot delete current deck");
            }
        }

        [Authorize]
        [HttpPut("{deckId}")]
        public ActionResult<Deck> MakeCurrent(int deckId)
        {
            var deck = _decksService.MakeCurrent(deckId, User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            return deck == null ? NotFound() : Ok(deck);
        }

        [Authorize]
        [HttpPut("{deckId}/{CardId}")]
        public ActionResult<Deck> AddCard(int deckId, int cardId)
        {
            try
            {
                var deck = _decksService.AddCard(deckId, cardId, User.FindFirstValue(ClaimTypes.NameIdentifier)!);
                return deck == null ? NotFound() : Ok(deck);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("The deck or the card does not belong to the player");
            }
            catch (InvalidOperationException)
            {
                return BadRequest("The card cannot be added to the deck");
            }
        }

        [Authorize]
        [HttpPut("{deckId}/{CardId}")]
        public ActionResult<Deck> RemoveCard(int deckId, int cardId)
        {
            try
            {
                var deck = _decksService.RemoveCard(deckId, cardId, User.FindFirstValue(ClaimTypes.NameIdentifier)!);
                return deck == null ? NotFound() : Ok(deck);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("The deck or the card does not belong to the player");
            }
            catch (InvalidOperationException)
            {
                return BadRequest("The card is already in the deck");
            }
        }
    }
}
