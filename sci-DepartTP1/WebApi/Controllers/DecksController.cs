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

        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<Deck>> GetDecks()
        {
            return Ok(_decksService.GetPlayerDecks(User.FindFirstValue(ClaimTypes.NameIdentifier)!));
        }

        [Authorize]
        [HttpGet("{deckId}")]
        public ActionResult<IEnumerable<Card>> GetDeckCards(int deckId)
        {
            var ownedCards = _decksService.GetDeckOwnedCards(deckId, User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            return Ok(ownedCards.Select(oc => oc.Card));
        }

        [HttpPost("{name}")]
        public ActionResult<Deck> CreateDeck(string name)
        {
            var deck = _decksService.Create(name, User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            return Ok(deck);
        }

        // DELETE: api/Decks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeck(int id)
        {
            var deck = await _context.Decks.FindAsync(id);
            if (deck == null)
            {
                return NotFound();
            }

            _context.Decks.Remove(deck);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeckExists(int id)
        {
            return _context.Decks.Any(e => e.Id == id);
        }
    }
}
