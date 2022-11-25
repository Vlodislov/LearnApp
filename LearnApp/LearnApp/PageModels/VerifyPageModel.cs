using LearnApp.PageModels.Base;
using LearnApp.Services.Account;
using LearnApp.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LearnApp.PageModels.test
{
    public class VerifyPageModel : PageModelBase
    {
        private ICommand _sendEmail;
        public ICommand SendEmail
        {
            get => _sendEmail;
            set => SetProperty(ref _sendEmail, value);
        }

        private INavigationService _navigationService;
        private IAccountService _accountService;
        public VerifyPageModel(INavigationService navigationService, IAccountService accountService)
        {
            _navigationService = navigationService;
            _accountService = accountService;
            _sendEmail = new Command(SendE);
        }

        private void SendE(object obj)
        {
            if (_sendEmail is null)
            {
                Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Ошибка", "Письмо уже отправлено", "Oк");
            }
            else
            {
                _accountService.SendEmailVerify();
                _sendEmail = null;
                App.Current.MainPage.Navigation.PopAsync();
                Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Ошибка", "Подтвердите почту и повторите попытку", "Oк");
            }

        }
    }
}
