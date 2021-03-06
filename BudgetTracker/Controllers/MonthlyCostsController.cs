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
        
        // GET: MonthlyCosts/Create
        public async Task<IActionResult> Create()
        {
            var user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var budgetContext = await _context.MonthlyCosts
                //.Where(p => p.UserId == user)
                .Include(p => p.Subcat)
                //.Include(p => p.Cat);
                .ToListAsync();

            return View(budgetContext);
        }

        // POST: MonthlyCosts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubcatId,ActualCost,Difference,UserId,CatId,Id")] List<MonthlyCost> monthlyCost)
        {
            for(int i = 0; i < monthlyCost.Count(); i++)
            {
                if (ModelState.IsValid)
                {
                    monthlyCost[i].UserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    _context.Add(monthlyCost);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Create));
                }
            }



            //ViewData["SubcatId"] = new SelectList(_context.Subcats, "SubcatId", "SubcatName", monthlyCostSubcatId);
            //ViewData["CatId"] = new SelectList(_context.ExpenseCategories, "CatId", "CategoryName", monthlyCost.CatId);
            return RedirectToAction("Create");
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
