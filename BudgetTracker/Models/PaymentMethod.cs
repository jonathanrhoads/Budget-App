using System;
using System.Collections.Generic;

#nullable disable

namespace BudgetTracker.Models
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            Purchases = new HashSet<Purchase>();
        }

        public int PaymentMethodId { get; set; }
        public string PaymentMethodName { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
