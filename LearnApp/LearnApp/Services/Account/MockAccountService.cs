using LearnApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearnApp.Services.Account
{
    public class MockAccountService : IAccountService
    {

        public Task<bool> LoginAsync(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return Task.FromResult(true);
            }
            return Task.FromResult(false);

        }

        public void LogOut()
        {
            throw new NotImplementedException();
        }

        public bool GetU()
        {
            throw new NotImplementedException();
        }

        public void SendEmailVerify()
        {
            throw new NotImplementedException();
        }

        public bool IsVerify()
        {
            throw new NotImplementedException();
        }

        public bool SendResetPass(string email)
        {
            throw new NotImplementedException();
        }

        public string GetNameAccount()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SendOtpCodeAsync(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public Task<bool> VerifyOtpCodeAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task<AuthenticatedUser> GetUserAsync()
        {
            throw new NotImplementedException();
        }

        public string GetEmailAccount()
        {
            throw new NotImplementedException();
        }

        public void SendChangeEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
