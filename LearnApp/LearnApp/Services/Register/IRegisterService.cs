using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearnApp.Services.Register
{
    public interface IRegisterService
    {
        /// <summary>
        /// Метод выполняет регистрацию в приложение
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<bool> RegisterAsync(string username, string password);
        void SendEmail();
        bool IsVerif();
    }
}
