using LearnApp.PageModels.Base;
using LearnApp.PageModels.test;
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
    public class LoginPageModel : PageModelBase
    {
        bool isFirstOpen = true;

        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }
        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }
        private ICommand _loginInCommand;
        public ICommand LoginInCommand
        {
            get => _loginInCommand;
            set => SetProperty(ref _loginInCommand, value);
        }
        private ICommand _registerInCommand;
        public ICommand RegisterInCommand
        {
            get => _registerInCommand;
            set => SetProperty(ref _registerInCommand, value);
        }
        private INavigationService _navigationService;
        private IAccountService _accountService;

        private ICommand _resetPass;
        public ICommand ResetPass
        {
            get => _resetPass;
            set => SetProperty(ref _resetPass, value);
        }

        private ICommand _loginPhoneCommand;
        public ICommand LoginPhoneCommand
        {
            get => _loginPhoneCommand;
            set => SetProperty(ref _loginPhoneCommand, value);
        }

        public LoginPageModel(INavigationService navigationService, IAccountService accountService)
        {
            _navigationService = navigationService;
            _accountService = accountService;
            _loginInCommand = new Command(LoginIn);
            _resetPass = new Command(SendResetPass);
            _registerInCommand = new Command(Registerin);
            _loginPhoneCommand = new Command(LoginPhone);
        }

        private async void LoginPhone(object obj)
        {
            await _navigationService.NavigateToAsync<LoginPhoneModel>();
        }

        private async void Registerin(object obj)
        {
            await _navigationService.NavigateToAsync<RegisterPageModel>();

        }

        private async void SendResetPass(object obj)
        {
            await _navigationService.NavigateToAsync<SendEmailResetPasswordModel>();

        }

        private async void LoginIn(object obj)
        {
            if (!(Email is null) && !(Password is null))
            {
                var registerAttempt = await _accountService.LoginAsync(Email, Password);
                if (registerAttempt)
                {
                    if (_accountService.IsVerify())
                    {
                        await _navigationService.NavigateToAsync<DashBoardPageModel>();
                    }
                    else
                    {
                        if (isFirstOpen)
                        {
                            var pop = new MessageBoxPage("Ошибка!", "Вы не подтвердили почту! Проверьте почту...");
                            await App.Current.MainPage.Navigation.PushPopupAsync(pop, true);
                            isFirstOpen = false;
                        }
                        else
                        {
                            var pop = new MessageBoxPage("Ошибка!", "Вы не подтвердили почту! Проверьте почту...");
                            await App.Current.MainPage.Navigation.PushPopupAsync(pop, true);
                        }
                    }
                }
                else
                {
                    var pop = new MessageBoxPage("Ошибка!", "Неверный Email или Пароль");
                    await App.Current.MainPage.Navigation.PushPopupAsync(pop, true);

                }
            }
            else
            {
                var pop = new MessageBoxPage("Ошибка!", "Вы не ввели Email и Пароль");
                await App.Current.MainPage.Navigation.PushPopupAsync(pop, true);

            }


        }
    }
}
