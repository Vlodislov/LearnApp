using LearnApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearnApp.Services.Account
{
    public interface IAccountService
    {
        Task<bool> LoginAsync(string username, string password);
        bool GetU();
        void LogOut();
        void SendEmailVerify();
        bool IsVerify();
        bool SendResetPass(string email);
        void SendChangeEmail(string email);
        string GetNameAccount();
        string GetEmailAccount();
        Task<bool> SendOtpCodeAsync(string phoneNumber);
        Task<bool> VerifyOtpCodeAsync(string code);

        Task<AuthenticatedUser> GetUserAsync();
    }
}
