using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BudgetTracker.Models;
using System.Security.Claims;

namespace BudgetTracker.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly BudgetContext _context;

        public ExpensesController(BudgetContext context)
        {
            _context = context;
        }

        // GET: Expenses
        public async Task<IActionResult> Index()
        {
            var user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var budgetContext = _context.Expenses
                
                .Where(e => e.UserId == user)
                .Include(e => e.ApplicationUser);

            return View(await budgetContext.ToListAsync());
        }

        // GET: Expenses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenses = await _context.Expenses
                .Include(e => e.ApplicationUser)
                .FirstOrDefaultAsync(m => m.ExpenseId == id);
            if (expenses == null)
            {
                return NotFound();
            }

            return View(expenses);
        }

        // GET: Expenses/Create
        public IActionResult Create()
        {
            
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return View();
        }

        // POST: Expenses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExpenseId,UserId,MortgageRent,Phone,Gas,WaterSewerTrash,Electricity,CableInternet,HomeAlarmSystem,MaintenanceRepairs,VehiclePayment,Insurance,Fuel,UberLyft,LicenseRegistration,Maintenance,HomeRenters,Health,Dental,Vision,Pet,Life,Groceries,DiningOut,Coffee,ClothesShoes,SchoolTuitionSupplies,SportsOrganizationFees,Childcare,LunchMoney,ToysGames,HairCutsSalon,ManiPediWaxing,ClothesShoesAccessories,DryCleaning,GymSupplements,OrganizationDuesFees,Music,Video,MovieTheater,Concerts,SportingEvents,DateNights,Alchohol,TobaccoVaping,PersonalLoan,CreditCard,StudentLoan,Federal,State,Medicare,SocialSecurityFICA,EmergencySavings,CDsMoneyMarkets,IRA401k,StocksMutualFunds,Tithesffering,Charity,RetirementHome,Attorney,AlimonyChildSupport,LienJudgmentPayment,MonthlyIncome,TotalCost,IncomeVsTotal")] Expenses expenses)
        {
            if (ModelState.IsValid)
            {
                expenses.UserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                expenses.TotalCost = expenses.MortgageRent + expenses.Phone + expenses.Gas + expenses.WaterSewerTrash +
                    expenses.Electricity + expenses.CableInternet +
                    expenses.HomeAlarmSystem + expenses.MaintenanceRepairs + expenses.VehiclePayment + expenses.Insurance +
                    expenses.Fuel + expenses.UberLyft + expenses.LicenseRegistration + expenses.Maintenance +
                    expenses.HomeRenters + expenses.Health + expenses.Dental + expenses.Vision + expenses.Pet +
                    expenses.Life + expenses.Groceries + expenses.DiningOut +
                    expenses.Coffee + expenses.ClothesShoes + expenses.SchoolTuitionSupplies +
                    expenses.SportsOrganizationFees + expenses.Childcare +
                    expenses.LunchMoney + expenses.ToysGames + expenses.HairCutsSalon + expenses.ManiPediWaxing +
                    expenses.ClothesShoesAccessories +
                    expenses.DryCleaning + expenses.GymSupplements + expenses.OrganizationDuesFees + expenses.Music +
                    expenses.Video + expenses.MovieTheater +
                    expenses.Concerts + expenses.SportingEvents + expenses.DateNights + expenses.Alchohol +
                    expenses.TobaccoVaping + expenses.PersonalLoan + expenses.CreditCard +
                    expenses.StudentLoan + expenses.Federal + expenses.State + expenses.Medicare +
                    expenses.SocialSecurityFICA + expenses.EmergencySavings + expenses.CDsMoneyMarkets +
                    expenses.IRA401k + expenses.StocksMutualFunds + expenses.Tithesffering + expenses.Charity +
                    expenses.RetirementHome + expenses.Attorney +
                    expenses.AlimonyChildSupport + expenses.LienJudgmentPayment;
                expenses.IncomeVsTotal = expenses.MonthlyIncome - expenses.TotalCost;
                _context.Add(expenses);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", expenses.UserId);
            return View(expenses);
        }

        
            

        // GET: Expenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenses = await _context.Expenses.FindAsync(id);
            if (expenses == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", expenses.UserId);
            return View(expenses);
        }

        // POST: Expenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExpenseId,UserId,MortgageRent,Phone,Gas,WaterSewerTrash,Electricity,CableInternet,HomeAlarmSystem,MaintenanceRepairs,VehiclePayment,Insurance,Fuel,UberLyft,LicenseRegistration,Maintenance,HomeRenters,Health,Dental,Vision,Pet,Life,Groceries,DiningOut,Coffee,ClothesShoes,SchoolTuitionSupplies,SportsOrganizationFees,Childcare,LunchMoney,ToysGames,HairCutsSalon,ManiPediWaxing,ClothesShoesAccessories,DryCleaning,GymSupplements,OrganizationDuesFees,Music,Video,MovieTheater,Concerts,SportingEvents,DateNights,Alchohol,TobaccoVaping,PersonalLoan,CreditCard,StudentLoan,Federal,State,Medicare,SocialSecurityFICA,EmergencySavings,CDsMoneyMarkets,IRA401k,StocksMutualFunds,Tithesffering,Charity,RetirementHome,Attorney,AlimonyChildSupport,LienJudgmentPayment,MonthlyIncome,TotalCost,IncomeVsTotal")] Expenses expenses)
        {
            if (id != expenses.ExpenseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    expenses.TotalCost = expenses.MortgageRent + expenses.Phone + expenses.Gas + expenses.WaterSewerTrash +
                        expenses.Electricity + expenses.CableInternet +
                        expenses.HomeAlarmSystem + expenses.MaintenanceRepairs + expenses.VehiclePayment + expenses.Insurance +
                        expenses.Fuel + expenses.UberLyft + expenses.LicenseRegistration + expenses.Maintenance +
                        expenses.HomeRenters + expenses.Health + expenses.Dental + expenses.Vision + expenses.Pet +
                        expenses.Life + expenses.Groceries + expenses.DiningOut +
                        expenses.Coffee + expenses.ClothesShoes + expenses.SchoolTuitionSupplies +
                        expenses.SportsOrganizationFees + expenses.Childcare +
                        expenses.LunchMoney + expenses.ToysGames + expenses.HairCutsSalon + expenses.ManiPediWaxing +
                        expenses.ClothesShoesAccessories +
                        expenses.DryCleaning + expenses.GymSupplements + expenses.OrganizationDuesFees + expenses.Music +
                        expenses.Video + expenses.MovieTheater +
                        expenses.Concerts + expenses.SportingEvents + expenses.DateNights + expenses.Alchohol +
                        expenses.TobaccoVaping + expenses.PersonalLoan + expenses.CreditCard +
                        expenses.StudentLoan + expenses.Federal + expenses.State + expenses.Medicare +
                        expenses.SocialSecurityFICA + expenses.EmergencySavings + expenses.CDsMoneyMarkets +
                        expenses.IRA401k + expenses.StocksMutualFunds + expenses.Tithesffering + expenses.Charity +
                        expenses.RetirementHome + expenses.Attorney +
                        expenses.AlimonyChildSupport + expenses.LienJudgmentPayment;
                    expenses.IncomeVsTotal = expenses.MonthlyIncome - expenses.TotalCost;
                    _context.Update(expenses);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpensesExists(expenses.ExpenseId))
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
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", expenses.UserId);
            return View(expenses);
        }

        // GET: Expenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenses = await _context.Expenses
                .Include(e => e.ApplicationUser)
                .FirstOrDefaultAsync(m => m.ExpenseId == id);
            if (expenses == null)
            {
                return NotFound();
            }

            return View(expenses);
        }

        // POST: Expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expenses = await _context.Expenses.FindAsync(id);
            _context.Expenses.Remove(expenses);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpensesExists(int id)
        {
            return _context.Expenses.Any(e => e.ExpenseId == id);
        }
    }
}
