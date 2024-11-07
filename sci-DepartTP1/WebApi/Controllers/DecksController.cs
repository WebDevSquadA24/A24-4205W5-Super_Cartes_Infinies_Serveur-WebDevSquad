using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
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
        private CardsService _cardsService;

        public DecksController(ApplicationDbContext context, DecksService decksService, CardsService cardsService)
        {
            _context = context;
            _decksService = decksService;
            _cardsService = cardsService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Deck>> GetDecks()
        {
            var decks = _decksService.GetDecks(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            return Ok(decks);
        }

        [HttpGet("{deckId}")]
        public async Task<ActionResult<IEnumerable<Card>>> GetDeckCards(int deckId)
        {
            Deck? deck = await _decksService.GetDeck(deckId);

            if (deck == null) 
                return NotFound();

            return Ok(deck.OwnedCards.Select(oc => oc.Card));
        }

        [HttpGet("{deckId}")]
        public async Task<ActionResult<IEnumerable<Card>>> GetCardsNotInDeck(int deckId)
        {
            Deck? deck = await _decksService.GetDeck(deckId);

            if (deck == null)
                return NotFound();

            var playerCard = _cardsService.GetPlayersCards(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var cards = new List<Card>();
            foreach (var card in playerCard)
            {
                if (!deck.OwnedCards.Select(oc => oc.Card).Contains(card))
                    cards.Add(card);
            }
            return Ok(cards);
        }

        [HttpPost("{name}")]
        public async Task<ActionResult<Deck>> Create(string name)
        {
            var deck = await _decksService.Create(name, User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            return Ok(deck);
        }

        [Authorize]
        [HttpDelete("{deckId}")]
        public async Task<IActionResult> Delete(int deckId)
        {
            try
            {
                await _decksService.Delete(deckId, User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            } 
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                return Unauthorized(e.Message);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }

            return NoContent();
        }

        [Authorize]
        [HttpPut("{deckId}")]
        public async Task<ActionResult<Deck>> MakeCurrent(int deckId)
        {
            var deck = await _decksService.MakeCurrent(deckId, User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            return Ok(deck);
        }

        [Authorize]
        [HttpPut("{deckId}/{CardId}")]
        public async Task<ActionResult<Deck>> AddCard(int deckId, int cardId)
        {
            try
            {
                var deck = await _decksService.AddCard(deckId, cardId, User.FindFirstValue(ClaimTypes.NameIdentifier)!);
                return Ok(deck);
            }
            catch (UnauthorizedAccessException e)
            {
                return Unauthorized(e.Message);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
