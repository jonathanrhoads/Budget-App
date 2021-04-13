using System;
using System.Collections.Generic;

#nullable disable

namespace BudgetTracker.Models
{
    public partial class MonthlyCost
    {
        public int SubcatId { get; set; }
        public decimal? ProjectedCost { get; set; }
        public decimal? ActualCost { get; set; }
        public decimal? Difference { get; set; }
        public string UserId { get; set; }
        

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Subcat Subcat { get; set; }
        // public virtual AspNetUser User { get; set; }
    }
}
