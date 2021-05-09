﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BudgetTracker.Models
{
    public partial class MonthlyCost
    {
        [Key]
        public int Id { get; set; }
        public int MonthlyCostId { get; set; }
        public int SubcatId { get; set; }
        public int CatId { get; set; }
        public decimal? ProjectedCost { get; set; }
        public decimal? ActualCost { get; set; }
        public decimal? Difference { get; set; }
        public string UserId { get; set; }
         
        public virtual ExpenseCategory Cat { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Subcat Subcat { get; set; }
        
    }
}
