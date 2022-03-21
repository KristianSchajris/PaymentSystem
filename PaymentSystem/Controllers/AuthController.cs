using Microsoft.AspNetCore.Mvc;
using PaymentSystem.Interfaces.IServices;
using PaymentSystem.Requests;
using PaymentSystem.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaymentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // POST api/<AuthController>
        [HttpPost("login")]
        public IActionResult Post([FromBody] AuthRequest authRequest)
        {
            var response = new Response();

            var userResponse  = _authService.AuthLogin(authRequest);

            if (userResponse != null)
            {
                response.Data    = userResponse;
                response.Success = true;
                response.Message = "La solicitud se realizo exitosamente.";

                return Ok(response);
            }

            response.Message = "Lo sentimos, su correo electronico o contraseña errada, porfavor intete de nuevo.";

            return BadRequest(response);
        }

    }
}
