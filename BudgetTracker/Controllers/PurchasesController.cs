using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BudgetTracker.Models;
using Google.DataTable.Net.Wrapper.Extension;
using Google.DataTable.Net.Wrapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Security.Claims;

namespace BudgetTracker.Controllers
{
    public class PurchasesController : Controller
    {
        private readonly BudgetContext _context;
        

        public PurchasesController(BudgetContext context)
        {
            _context = context;
        }

        // GET: Purchases
        public async Task<IActionResult> Index()
        {       
            var user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var budgetContext = _context.Purchases
                .Where(p => p.UserId == user)
                .Include(p => p.Cat)
                .Include(p => p.PaymentMethod);
            return View(await budgetContext.ToListAsync());
        }

        // GET: Purchases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _context.Purchases
                .Include(p => p.Cat)
                .Include(p => p.PaymentMethod)
                .FirstOrDefaultAsync(m => m.PurchaseId == id);
            if (purchase == null)
            {
                return NotFound();
            }

            return View(purchase);
        }

        // GET: Purchases/Create
        public IActionResult Create()
        {
            ViewData["CatId"] = new SelectList(_context.ExpenseCategories, "CatId", "CategoryName");
            ViewData["PaymentMethodId"] = new SelectList(_context.PaymentMethods, "PaymentMethodId", "PaymentMethodName");
            return View();
        }

        // POST: Purchases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PurchaseId,CatId,PurchaseName,Price,PaymentMethodId,Note,Necessity,PurchaseDate, UserId")] Purchase purchase)
        {
            
            if (ModelState.IsValid)
            {
                purchase.UserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                _context.Add(purchase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CatId"] = new SelectList(_context.ExpenseCategories, "CatId", "CategoryName", purchase.CatId);
            ViewData["PaymentMethodId"] = new SelectList(_context.PaymentMethods, "PaymentMethodId", "PaymentMethodName", purchase.PaymentMethodId);
            return View(purchase);
        }

        // GET: Purchases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _context.Purchases.FindAsync(id);
            if (purchase == null)
            {
                return NotFound();
            }
            ViewData["CatId"] = new SelectList(_context.ExpenseCategories, "CatId", "CategoryName", purchase.CatId);
            ViewData["PaymentMethodId"] = new SelectList(_context.PaymentMethods, "PaymentMethodId", "PaymentMethodName", purchase.PaymentMethodId);
            return View(purchase);
        }

        // POST: Purchases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PurchaseId,CatId,PurchaseName,Price,PaymentMethodId,Note,Necessity,PurchaseDate")] Purchase purchase)
        {
            if (id != purchase.PurchaseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    purchase.UserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    _context.Update(purchase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseExists(purchase.PurchaseId))
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
            ViewData["CatId"] = new SelectList(_context.ExpenseCategories, "CatId", "CategoryName", purchase.CatId);
            ViewData["PaymentMethodId"] = new SelectList(_context.PaymentMethods, "PaymentMethodId", "PaymentMethodName", purchase.PaymentMethodId);
            return View(purchase);
        }

        // GET: Purchases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _context.Purchases
                .Include(p => p.Cat)
                .Include(p => p.PaymentMethod)
                .FirstOrDefaultAsync(m => m.PurchaseId == id);
            if (purchase == null)
            {
                return NotFound();
            }

            return View(purchase);
        }

        // POST: Purchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchase = await _context.Purchases.FindAsync(id);
            _context.Purchases.Remove(purchase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool PurchaseExists(int id)
        {
            return _context.Purchases.Any(e => e.PurchaseId == id);
        }

        [HttpPost]
        public JsonResult AjaxMethod()
        {
            var budgetContext = _context.Purchases.Include(p => p.Cat).Include(p => p.PaymentMethod);

            var list = budgetContext.ToList();
            var json = list.ToGoogleDataTable()
               .NewColumn(new Column(ColumnType.String, "Category"), x => x.Cat.CategoryName)
               .NewColumn(new Column(ColumnType.Number, "Price"), x => x.Price)
               .Build()
               .GetJson();

            return Json(json);
        }

        public ViewResult Summary()
        {
            
            return View();
        }

        
    }
}
