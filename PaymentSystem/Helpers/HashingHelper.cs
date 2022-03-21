using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystem.Helpers
{
    public class HashingHelper
    {
        public static string Sha256Hash(string data)
        {
            SHA256 sha256Hash = SHA256.Create();
            byte[] bytes      = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(data));
            var builder       = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }

            return builder.ToString();
        }
    }
}
