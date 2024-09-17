using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Models.Models.ViewModels;
using Super_Cartes_Infinies.Data;

namespace Super_Cartes_Infinies.Controllers
{
    [Authorize(Roles = "admin")]
    public class StarterCardsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StarterCardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StarterCards
        // Tri par le nom de la carte
        public async Task<IActionResult> Index()
        {
            var startingCards = await _context.StarterCards.OrderBy(sc => sc.Card.Name).ToListAsync();
            return View(startingCards);
        }

        // GET: StarterCards/Create
        public IActionResult Create()
        {
            var cards = _context.Cards.ToList();
            var viewModel = new StarterCardViewModel
            {
                Cards = cards
            };
            return View(viewModel);
        }

        // POST: StarterCards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StarterCardViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var starterCard = new StarterCard
                {
                    CardId = viewModel.SelectedCardId
                };

                _context.Add(starterCard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            viewModel.Cards = _context.Cards.ToList();
            return View(viewModel);
        }

        // GET: StarterCards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listeCards = await _context.Cards.ToListAsync();
            var starterCard = await _context.StarterCards.FindAsync(id);
            if (starterCard == null)
            {
                return NotFound();
            }
            var viewModel = new StarterCardViewModel
            {
                Cards = listeCards,
                StarterCard = starterCard,
                SelectedCardId = starterCard.CardId
            };
            return View(viewModel);
        }

        // POST: StarterCards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] StarterCard starterCard)
        {
            if (id != starterCard.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(starterCard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StarterCardExists(starterCard.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(starterCard);
        }

        // GET: StarterCards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var starterCard = await _context.StarterCards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (starterCard == null)
            {
                return NotFound();
            }

            return View(starterCard);
        }

        // POST: StarterCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var starterCard = await _context.StarterCards.FindAsync(id);
            if (starterCard != null)
            {
                _context.StarterCards.Remove(starterCard);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StarterCardExists(int id)
        {
            return _context.StarterCards.Any(e => e.Id == id);
        }

        // Retourne les détails d'une carte en JSON basée sur l'ID fourni.
        // Utilisé pour afficher les informations d'une carte sélectionnée dans le formulaire de création.
        [HttpGet]
        public JsonResult GetCardDetails(int id)
        {
            var card = _context.Cards.FirstOrDefault(c => c.Id == id);
            if (card == null)
            {
                return Json(null);
            }

            return Json(new
            {
                name = card.Name,
                attack = card.Attack,
                health = card.Health,
                cost = card.Cost,
                imageUrl = card.ImageUrl
            });
        }

    }
}
