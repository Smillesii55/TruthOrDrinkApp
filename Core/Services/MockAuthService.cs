using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class MockAuthService : IAuthService
    {
        public Task<bool> LoginAsync(string email, string password)
        {
            // Voor nu: simpele mock
            // Later kun je hier echte DB/API-aanroep van maken.
            var isValid = !string.IsNullOrWhiteSpace(email)
                          && !string.IsNullOrWhiteSpace(password)
                          && password.Length >= 4;

            return Task.FromResult(isValid);
        }
    }
}

