using System;
using System.Collections.Generic;

#nullable disable

namespace BudgetTracker.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public decimal? UserIncome1 { get; set; }
        public decimal? UserIncome2 { get; set; }
    }
}
