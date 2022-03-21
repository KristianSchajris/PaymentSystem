using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentSystem.Requests;
using PaymentSystem.Responses;

namespace PaymentSystem.Interfaces.IServices
{
    public interface IAuthService
    {
        AuthResponse AuthLogin(AuthRequest authRequest);
    }
}
