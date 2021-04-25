using BudgetTracker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BudgetTracker.Controllers
{
    public class MonthlyCostsController : Controller
    {

        private readonly BudgetContext _context;

        public MonthlyCostsController(BudgetContext context)
        {
            _context = context;
        }
        
        // GET: MonthlyCosts
        public async Task<IActionResult> BudgetUpdate([Bind("SubcatId,ProjectedCost,ActualCost,Difference,UserId")] MonthlyCost monthlyCost)
        {
            var user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var budgetContext = _context.MonthlyCosts
                .Where(p => p.UserId == user)
                .Include(p => p.Subcat)
                .Include(p => p.Subcat.Cat);
            return View(monthlyCost);
        }

        // GET: MonthlyCosts/Create
        public async Task<IActionResult> Create()
        {
            var user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            
            var budgetContext = _context.MonthlyCosts
                .Where(p => p.UserId == user)
                .Include(p => p.Subcat)
                .Include(p => p.Subcat.Cat);
            
            return View(await budgetContext.ToListAsync());
        }

        // POST: MonthlyCosts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubcatId,ProjectedCost,ActualCost,Difference,UserId")] MonthlyCost monthlyCost)
        {
            
            if (ModelState.IsValid)
            {
                monthlyCost.UserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                _context.Add(monthlyCost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            ViewData["SubcatId"] = new SelectList(_context.Subcats, "SubcatId", "SubcatName", monthlyCost.SubcatId);
            ViewData["CatId"] = new SelectList(_context.ExpenseCategories, "CatId", "CategoryName", monthlyCost.Subcat.CatId);
            return View(monthlyCost);
        }

        // GET: MonthlyCosts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MonthlyCosts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MonthlyCosts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MonthlyCosts/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
