using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BudgetTracker.Models;

namespace BudgetTracker.Controllers
{
    public class SubcatsController : Controller
    {
        private readonly BudgetContext _context;

        public SubcatsController(BudgetContext context)
        {
            _context = context;
        }

        // GET: Subcats
        public async Task<IActionResult> Index()
        {
            var budgetContext = _context.Subcats.Include(s => s.Cat);
            return View(await budgetContext.ToListAsync());
        }

        // GET: Subcats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subcat = await _context.Subcats
                .Include(s => s.Cat)
                .FirstOrDefaultAsync(m => m.SubcatId == id);
            if (subcat == null)
            {
                return NotFound();
            }

            return View(subcat);
        }

        // GET: Subcats/Create
        public IActionResult Create()
        {
            ViewData["CatId"] = new SelectList(_context.ExpenseCategories, "CatId", "CategoryName");
            return View();
        }

        // POST: Subcats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubcatId,SubcatName,CatId")] Subcat subcat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subcat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CatId"] = new SelectList(_context.ExpenseCategories, "CatId", "CategoryName", subcat.CatId);
            return View(subcat);
        }

        // GET: Subcats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subcat = await _context.Subcats.FindAsync(id);
            if (subcat == null)
            {
                return NotFound();
            }
            ViewData["CatId"] = new SelectList(_context.ExpenseCategories, "CatId", "CategoryName", subcat.CatId);
            return View(subcat);
        }

        // POST: Subcats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubcatId,SubcatName,CatId")] Subcat subcat)
        {
            if (id != subcat.SubcatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subcat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubcatExists(subcat.SubcatId))
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
            ViewData["CatId"] = new SelectList(_context.ExpenseCategories, "CatId", "CategoryName", subcat.CatId);
            return View(subcat);
        }

        // GET: Subcats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subcat = await _context.Subcats
                .Include(s => s.Cat)
                .FirstOrDefaultAsync(m => m.SubcatId == id);
            if (subcat == null)
            {
                return NotFound();
            }

            return View(subcat);
        }

        // POST: Subcats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subcat = await _context.Subcats.FindAsync(id);
            _context.Subcats.Remove(subcat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubcatExists(int id)
        {
            return _context.Subcats.Any(e => e.SubcatId == id);
        }
    }
}
