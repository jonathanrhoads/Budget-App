using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetTracker.Models.ViewModel
{
    public class BudgetPage
    {
        public Subcat Subcat { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public MonthlyCost MonthlyCost { get; set; }
        public ExpenseCategory ExpenseCategory { get; set; }
    }
}
