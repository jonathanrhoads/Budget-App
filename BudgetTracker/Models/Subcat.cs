using System;
using System.Collections.Generic;

#nullable disable

namespace BudgetTracker.Models
{
    public partial class Subcat
    {
        public int SubcatId { get; set; }
        public string SubcatName { get; set; }
        public int CatId { get; set; }

        public virtual ExpenseCategory Cat { get; set; }
    }
}
