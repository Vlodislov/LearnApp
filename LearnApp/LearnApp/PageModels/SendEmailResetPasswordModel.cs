using LearnApp.PageModels.Base;
using LearnApp.Pages;
using LearnApp.Services.Account;
using LearnApp.Services.Navigation;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LearnApp.PageModels
{

    public  class SendEmailResetPasswordModel : PageModelBase
    {

        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }


        private INavigationService _navigationService;
        private IAccountService _accountService;

        private ICommand _resetPass;
        public ICommand ResetPass
        {
            get => _resetPass;
            set => SetProperty(ref _resetPass, value);
        }

        public SendEmailResetPasswordModel(INavigationService navigationService, IAccountService accountService)
        {
            _navigationService = navigationService;
            _accountService = accountService;
            _resetPass = new Command(SendResetPass);
        }

        private async void SendResetPass(object obj)
        {
            if (!(Email is null) && (Email != ""))
            {
                _accountService.SendResetPass(Email);
                var pop = new MessageBoxPage("Почта", "Письмо отправлено на почту");
                await App.Current.MainPage.Navigation.PushPopupAsync(pop, true);
                await App.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                var pop = new MessageBoxPage("Ошибка!", "Введите Email в поле");
                await App.Current.MainPage.Navigation.PushPopupAsync(pop, true);
            }
        }
    }
}
