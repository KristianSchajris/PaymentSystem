using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentSystem.Requests
{
    public class OrderRequest
    {
        public decimal Total { get; set; }
        public DateTime OrderDate { get; set; }
        public long IdUser { get; set; }

        public List<OrderDetailRequest> OrderDetails { get; set; }

        public OrderRequest()
        {
            OrderDetails = new List<OrderDetailRequest>();
        }

    }
}
