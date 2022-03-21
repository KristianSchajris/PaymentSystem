using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentSystem.Responses
{
    public class Response
    {
        
        public bool Success { get; set; }
        public string Message { get; set; }
        public Object Data { get; set; }

        public Response()
        {
            Data    = null;
            Success = false;
        }
    }
}
