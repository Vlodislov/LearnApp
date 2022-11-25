using LearnApp.PageModels.Base;
using LearnApp.Pages;
using LearnApp.Services;
using LearnApp.Services.Account;
using LearnApp.Services.Navigation;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LearnApp.PageModels
{
    public class SettingsPageModel : PageModelBase
    {
        private string _user;
        public string User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }

        private ICommand _loginOutCommand;
        
        public ICommand LoginOutCommand
        {
            get => _loginOutCommand;
            set => SetProperty(ref _loginOutCommand, value);
        }

        private ICommand _sendEmailChangePassword;

        public ICommand SendEmailChangePassword
        {
            get => _sendEmailChangePassword;
            set => SetProperty(ref _sendEmailChangePassword, value);
        }
        private INavigationService _navigationService;
        private IAccountService _accountService;

        public SettingsPageModel(INavigationService navigationService, IAccountService accountService)
        {
            _navigationService = navigationService;
            _accountService = accountService;
            if(_accountService.GetU())
                User = _accountService.GetNameAccount();
            _loginOutCommand = new Command(LoginOut);
            _sendEmailChangePassword = new Command(SendEmailChange);
        }


        private async void SendEmailChange(object obj)
        {
            var res = _accountService.SendResetPass(_accountService.GetEmailAccount());
            if (res)
            {
                App.Current.MainPage = new NavigationPage(PageModelLocator.CreatePageFor(typeof(LoginPageModel)));
                _accountService.LogOut();
                await App.Current.MainPage.Navigation.PopAsync(); 
                var pop = new MessageBoxPage("", "После изменения пароля снова войдите в аккаунт");
                await App.Current.MainPage.Navigation.PushPopupAsync(pop, true);
            }
        }

        private void LoginOut(object obj)
        {
            _accountService.LogOut();
            App.Current.MainPage = new NavigationPage(PageModelLocator.CreatePageFor(typeof(LoginPageModel)));
        }
    }
}
