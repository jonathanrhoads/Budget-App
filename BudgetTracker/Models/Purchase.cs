using System;
using System.Collections.Generic;

#nullable disable

namespace BudgetTracker.Models
{
    public partial class Purchase
    {
        public int PurchaseId { get; set; }
        public int CatId { get; set; }
        public string PurchaseName { get; set; }
        public decimal Price { get; set; }
        public int? PaymentMethodId { get; set; }
        public string Note { get; set; }
        public int? Necessity { get; set; }
        public DateTime? PurchaseDate { get; set; }

        public virtual ExpenseCategory Cat { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
    }
}
