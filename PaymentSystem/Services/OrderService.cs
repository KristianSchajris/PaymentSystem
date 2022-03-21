using PaymentSystem.Interfaces.IServices;
using PaymentSystem.Models;
using PaymentSystem.Requests;
using PaymentSystem.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentSystem.Services
{
    public class OrderService : IOrderService
    {
        private PaymentSystemDBContext _context = new();

        public async void CreateOrder(OrderRequest request, decimal total)
        {
            var transaction = _context.Database.BeginTransaction();

            try
            {
                
                Order order = new()
                {
                    Total = total,
                    IdUser = request.IdUser,
                    OrderDate = request.OrderDate
                };

                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                foreach (var detail in request.OrderDetails)
                {
                    OrderDetail orderDetail = new()
                    {
                        Quantity  = detail.Quantity,
                        IdProduct = detail.IdProduct,
                        Value     = detail.Value,
                        IdOrder   = order.Id
                    };

                    _context.OrderDetails.Add(orderDetail);
                    await _context.SaveChangesAsync();
                }

                transaction.Commit();

            }
            catch (Exception)
            {
                transaction.Rollback();

                throw new Exception("Ocurrio un error, porfavor intetalo de nuevo.");
            }
        }
    }
}
