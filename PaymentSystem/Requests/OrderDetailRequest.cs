using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentSystem.Requests
{
    public class OrderDetailRequest
    {
        public int Quantity { get; set; }
        public decimal Value { get; set; }
        public long IdProduct { get; set; }
        public long IdOrder { get; set; }
    }
}
