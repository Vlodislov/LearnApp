using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearnApp.Services.Register
{
    public class MockRegisterService : IRegisterService
    {
        public bool IsVerif()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegisterAsync(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return Task.FromResult(false);
            }
            return Task.Delay(1000).ContinueWith((task) => true);
        }

        public void SendEmail()
        {
            throw new NotImplementedException();
        }
    }
}
