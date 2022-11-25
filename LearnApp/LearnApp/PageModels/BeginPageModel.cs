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
    class BeginPageModel : PageModelBase
    {
        private ICommand _goLogin;
        public ICommand GoLogin
        {
            get => _goLogin;
            set => SetProperty(ref _goLogin, value);
        }
        private INavigationService _navigationService;
        private IAccountService _accountService;

        public BeginPageModel(INavigationService navigationService, IAccountService accountService)
        {
            _navigationService = navigationService;
            _accountService = accountService;
            _goLogin = new Command(GoLog);
        }

        private async void GoLog(object obj)
        {
            
            if (_accountService.GetU())
            {
                if(_accountService.IsVerify())
                    await _navigationService.NavigateToAsync<DashBoardPageModel>();
                else
                {
                    App.Current.MainPage = PageModelLocator.CreatePageFor(typeof(LoginPageModel)); ;
                    await _navigationService.NavigateToAsync<LoginPageModel>();
                }
            }
            else
            {
                App.Current.MainPage = PageModelLocator.CreatePageFor(typeof(LoginPageModel)); ;
                await _navigationService.NavigateToAsync<LoginPageModel>();
            }
        }
    }
}
