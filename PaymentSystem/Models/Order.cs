using System;
using System.Collections.Generic;

#nullable disable

namespace PaymentSystem.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public long Id { get; set; }
        public DateTime OrderDate { get; set; }
        public long IdUser { get; set; }

        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
