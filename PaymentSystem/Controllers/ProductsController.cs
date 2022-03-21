using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentSystem.Responses;
using PaymentSystem.Models;
using Microsoft.EntityFrameworkCore;
using PaymentSystem.Requests;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaymentSystem.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private PaymentSystemDBContext _context = new();

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = new Response();
            try
            {
                var products = await _context.Products.Where(product => product.Stock > 0).ToListAsync();

                if (products == null)
                {
                    response.Message = "Lo sentimos ocurrio un error vuelva a intentarlo.";

                    return NotFound(response);
                }
                
                response.Message = "Solicitud realizada exitosamente.";
                response.Success = true;
                response.Data    = products;

                return Ok(response);

            }
            catch (Exception e)
            {
                response.Message = e.Message;

                return Ok(response);
            }
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id:long}")]
        public async Task<IActionResult> Get(long id)
        {
            var response = new Response();
            try
            {
                var product = await _context.Products
                    .Where(product => product.Id == id && product.Stock > 0)
                    .ToListAsync();

                if (product != null)
                {
                    response.Message = "La solicitud se realizo de forma exitosa.";
                    response.Success = true;
                    response.Data    = product;

                    return Ok(response);

                }

                response.Message = "El producto no se encuentra actualmente en nuestro catalogo.";

                return NotFound(response);

            }
            catch (Exception e)
            {
                response.Message = e.Message;

                return BadRequest(response);
            }
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            var response = new Response();
            try
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                response.Message = "El producto fue registrado con exito.";
                response.Success = true;
                response.Data    = product;
                
                return Ok(response);

            }
            catch (Exception e)
            {
                response.Message = e.InnerException.Message;

                return BadRequest(response);
            }
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id:long}")]
        public async Task<IActionResult> Put(long id, [FromBody] Product product)
        {
            var response = new Response();
            try
            {
                if (id != product.Id)
                {
                    response.Message = "Lo sentimos, este producto no se encuentra actualmente en nuestro catalogo.";
                    
                    return NotFound(response);
                }

                _context.Products.Update(product);
                await _context.SaveChangesAsync();

                return Ok(product);

            }
            catch (Exception e)
            {
                response.Message = e.InnerException.Message;

                return Ok(response);
            }
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var response = new Response();
            try
            {
                var product = await _context.Products.FindAsync(id);

                if (id != product.Id)
                {
                    response.Message = "Este producto se encuentra en el catalogo.";

                    return NotFound(response);
                }

                _context.Products.Remove(product);

                await _context.SaveChangesAsync();

                response.Message = "El producto fue eliminado del catalogo.";
                response.Success = true;
                response.Data    = product;

                return Ok(response);

            }
            catch (Exception e)
            {
                response.Message = e.Message;

                return BadRequest(response);
            }
        }
    }
}
