using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Models.VM;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;


namespace Super_Cartes_Infinies.Controllers
{
    [Authorize(Roles = "admin")]
    public class CardsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cards
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cards.Include(c => c.CardPowers).OrderBy(c => c.Name).ToListAsync());
        }

        // GET: Cards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Attack,Health,Cost,ImageUrl")] Card card)
        {
            if (ModelState.IsValid)
            {
                _context.Add(card);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(card);
        }

        // GET: Cards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = await _context.Cards.Include(c => c.CardPowers).ThenInclude(cp => cp.Power).FirstAsync(c => c.Id == id);
            if (card == null)
            {
                return NotFound();
            }


            CardVM cardVM = new CardVM();
            cardVM.Card = card;

            var powers = await _context.Powers.ToListAsync();
            var selectListPowers = powers.Select(item => new SelectListItem
            {
                Value = item.Id.ToString(),  // 'Id' is assumed to be the primary key
                Text = item.Name             // 'Name' is the property displayed in the dropdown
            }).ToList();
            cardVM.AvailablePowers = selectListPowers;

            return View(cardVM);
        }

        // POST: Cards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CardVM cardVM) /*[Bind("Id,Name,Attack,Health,Cost,ImageUrl")]*/
        {
            if (id != cardVM.Card.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    List<Power> powers = await _context.Powers.ToListAsync();
                    List<SelectListItem> selectListPowers = powers.Select(item => new SelectListItem
                    {
                        Value = item.Id.ToString(),  // 'Id' is assumed to be the primary key
                        Text = item.Name             // 'Name' is the property displayed in the dropdown
                    }).ToList();
                    cardVM.AvailablePowers = selectListPowers;

                    int selectedValue = cardVM.SelectedPowerId;

                    // You can now process the selected value (for example, retrieve the selected item)
                    Power selectedPower = _context.Powers.FirstOrDefault(x => x.Id == selectedValue);

                    CardPower cardPower = new CardPower
                    {
                        Card = cardVM.Card,
                        CardId = cardVM.Card.Id,
                        Power = selectedPower,
                        PowerId = cardVM.SelectedPowerId,
                        Value = cardVM.PowerValue,
                    };

                    
                    cardVM.Card.CardPowers.Add(cardPower);

                    _context.Update(cardVM.Card);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardExists(cardVM.Card.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Edit));
            }

            return View(cardVM);
        }

        // GET: Cards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = await _context.Cards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (card == null)
            {
                return NotFound();
            }

            return View(card);
        }

        // POST: Cards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var card = await _context.Cards.FindAsync(id);
            if (card != null)
            {
                _context.Cards.Remove(card);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardExists(int id)
        {
            return _context.Cards.Any(e => e.Id == id);
        }

        public async Task<IActionResult> DeletePower(int id, CardVM cardVm)
        {
            Card card = await _context.Cards.FindAsync(cardVm.Card.Id);
            cardVm.Card = card;
            List<CardPower> cardPowers = card.CardPowers;
            if (cardPowers != null)
            {
                CardPower cardPower = cardPowers.Find(x => x.Id == id);
                
                cardPowers.Remove(cardPower);
                _context.CardPowers.Remove(cardPower);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Edit), new { id = card.Id, cardVM = cardVm });
        }
    }
}
