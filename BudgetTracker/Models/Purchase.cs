using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace BudgetTracker.Models
{
    public partial class Purchase
    {
        public int PurchaseId { get; set; }

        [DisplayName("Category")]
        public int CatId { get; set; }
        [DisplayName("Purchase Name")]
        public string PurchaseName { get; set; }

        [DisplayName("Price")]
        public decimal Price { get; set; }


        public int? PaymentMethodId { get; set; }

        [DisplayName("Note")]
        public string Note { get; set; }

        [DisplayName("Necessity")]
        public int? Necessity { get; set; }

        [DisplayName("Date")]
        public DateTime? PurchaseDate { get; set; }

        [DisplayName("Expense Category")]
        public virtual ExpenseCategory Cat { get; set; }

        [DisplayName("Payment Method")]
        public virtual PaymentMethod PaymentMethod { get; set; }
    }
}
