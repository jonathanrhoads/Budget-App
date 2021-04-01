using System;
using System.Collections.Generic;

#nullable disable

namespace BudgetTracker.Models
{
    public partial class MonthlyCost
    {
        public int? UserId { get; set; }
        public int SubcatId { get; set; }
        public decimal? ProjectedCost { get; set; }
        public decimal? ActualCost { get; set; }
        public decimal? Difference { get; set; }

        public virtual Subcat Subcat { get; set; }
        public virtual User User { get; set; }
    }
}
