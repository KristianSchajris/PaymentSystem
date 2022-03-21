using System;
using System.Collections.Generic;

#nullable disable

namespace PaymentSystem.Models
{
    public partial class OrderDetail
    {
        public long Id { get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; }
        public long IdProduct { get; set; }
        public long IdOrder { get; set; }

        public virtual Order IdOrderNavigation { get; set; }
        public virtual Product IdProductNavigation { get; set; }
    }
}
