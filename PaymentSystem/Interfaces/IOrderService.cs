using PaymentSystem.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentSystem.Interfaces.IServices
{
    public interface IOrderService
    {
        public void CreateOrder(OrderRequest request, decimal total);
    }
}
