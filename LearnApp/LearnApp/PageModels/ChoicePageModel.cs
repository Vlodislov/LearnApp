using LearnApp.Models;
using LearnApp.PageModels.Base;
using LearnApp.Services.Account;
using LearnApp.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LearnApp.PageModels
{
    public class ChoicePageModel : PageModelBase
    {
       
        private ICommand _loginInCommand;
        public ICommand LoginInCommand
        {
            get => _loginInCommand;
            set => SetProperty(ref _loginInCommand, value);
        }
        private ICommand _loginPhoneCommand;
        public ICommand LoginPhoneCommand
        {
            get => _loginPhoneCommand;
            set => SetProperty(ref _loginPhoneCommand, value);
        }

        private INavigationService _navigationService;
        private IAccountService _accountService;

       
        public bool IsLogedIn { get; set; }
        public ChoicePageModel(INavigationService navigationService, IAccountService accountService)
        {
            _navigationService = navigationService;
            _accountService = accountService;
           
            _loginInCommand = new Command(LoginIn);
            _loginPhoneCommand = new Command(LoginPhone);
        }

    
        private async void LoginPhone(object obj)
        {
            await _navigationService.NavigateToAsync<LoginPhoneModel>();
        }

        private async void LoginIn(object obj)
        {
                await _navigationService.NavigateToAsync<LoginPageModel>();
        }
    }
}
