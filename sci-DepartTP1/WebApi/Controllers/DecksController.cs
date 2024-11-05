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
            return Ok(_decksService.GetDecks(User.FindFirstValue(ClaimTypes.NameIdentifier)!));
        }

        [HttpGet("{deckId}")]
        public async Task<ActionResult<IEnumerable<Card>>> GetDeckCards(int deckId)
        {
            Deck? deck = await _decksService.GetDeck(deckId);

            if (deck == null) 
                return NotFound();

            return Ok(deck.OwnedCards.Select(oc => oc.Card));
        }

        [HttpPost("{name}")]
        public async Task<ActionResult<Deck>> CreateDeck(string name)
        {
            Deck deck = await _decksService.Create(name, User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            return Ok(deck);
        }

        [Authorize]
        [HttpDelete("{deckId}")]
        public async Task<IActionResult> DeleteDeck(int deckId)
        {
            var deck = await _decksService.GetDeck(deckId);
            if (deck == null)
            {
                return NotFound();
            }

            try
            {
                await _decksService.Delete(deck, User.FindFirstValue(ClaimTypes.NameIdentifier)!);
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

        private bool DeckExists(int id)
        {
            return _context.Decks.Any(e => e.Id == id);
        }
    }
}
