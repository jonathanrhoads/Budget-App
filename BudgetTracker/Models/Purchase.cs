using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BudgetTracker.Models
{
    public partial class Purchase
    {
        public int PurchaseId { get; set; }

        [DisplayName("Category")]
        public int CatId { get; set; }

        [DisplayName("Purchase Name")]
        [Required]
        public string PurchaseName { get; set; }

        [DisplayName("Price")]
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "You must enter a price greater than 0")]
        public decimal Price { get; set; }

        public string UserId { get; set; }
        public int? PaymentMethodId { get; set; }

        [DisplayName("Note")]
        public string Note { get; set; }

        [DisplayName("Necessity")]
        [Range(0, 10)]
        public int? Necessity { get; set; }

        [DisplayName("Date")]
        [Required]
        public DateTime? PurchaseDate { get; set; }

        [DisplayName("Expense Category")]
        public virtual ExpenseCategory Cat { get; set; }

        [DisplayName("Payment Method")]
        public virtual PaymentMethod PaymentMethod { get; set; }

        
    }
}
