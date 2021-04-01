using System;
using System.Collections.Generic;

#nullable disable

namespace BudgetTracker.Models
{
    public partial class ExpenseCategory
    {
        public ExpenseCategory()
        {
            Purchases = new HashSet<Purchase>();
            Subcats = new HashSet<Subcat>();
        }

        public int CatId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<Subcat> Subcats { get; set; }
    }
}
