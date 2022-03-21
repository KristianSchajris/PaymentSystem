using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaymentSystem.Interfaces.IServices;
using PaymentSystem.Models;
using PaymentSystem.Requests;
using PaymentSystem.Responses;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaymentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PaymentsController : ControllerBase
    {
        private IOrderService _orderService;

        public PaymentsController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // POST api/<PaymentsController>
        [HttpPost]
        public IActionResult Post([FromBody] OrderRequest request)
        {
            var response = new Response();

            // Facturar la suma de todos los productos al usuario en el servicio Facturar.
            var total = request.OrderDetails.Sum(detail => detail.Quantity * detail.Value);

            try
            {
                // Llamar al servicio de Logística para crear un pedido enviado.
                _orderService.CreateOrder(request, total);

                response.Data = new {
                    order = request,
                    total = total
                };

                response.Message = "Se ha realizado el pedido con exito.";
                response.Success = true;

                return Ok(response);
            } 
            catch(Exception e)
            {
                response.Message = e.Message;

                return BadRequest(response);
            }
        }
    }
}
