using LearnApp.Models;
using LearnApp.PageModels.Base;
using LearnApp.Pages;
using LearnApp.Services;
using LearnApp.Services.Account;
using LearnApp.Services.Navigation;
using Rg.Plugins.Popup.Extensions;
using System.Windows.Input;
using Xamarin.Forms;

namespace LearnApp.PageModels
{
    class LoginPhoneModel : PageModelBase
    {
        private string _phoneNumber;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set => SetProperty(ref _phoneNumber, value);
        }

        private string _code;
        public string Code
        {
            get => _code;
            set => SetProperty(ref _code, value);
        }

        private bool _codeSent;
        public bool CodeSent
        {
            get => _codeSent;
            set => SetProperty(ref _codeSent, value);
        }

        private string _buttonText = "Отправить код";
        public string ButtonText
        {
            get => _buttonText;
            set => SetProperty(ref _buttonText, value);
        }

        private ICommand _nextCommand;
        public ICommand NextCommand
        {
            get => _nextCommand;
            set => SetProperty(ref _nextCommand, value);
        }

        private IAccountService _accountService;
        private INavigationService _navigationService;
        private bool _codeRequested;

        public LoginPhoneModel(IAccountService accountService,
            INavigationService navigationService)
        {
            _accountService = accountService;
            _navigationService = navigationService;

            NextCommand = new Command(OnNextAction);
        }

        private async void OnNextAction(object obj)
        {
            if(!(PhoneNumber is null))
            {
                if (_codeRequested)
                {
                    var loginAttempt = await _accountService.VerifyOtpCodeAsync(Code);
                    if (loginAttempt)
                    {
                      
                        await _navigationService.NavigateToAsync<DashBoardPageModel>(true);
                    }
                    else
                    {
                        var pop = new MessageBoxPage("Ошибка!", "Неверный Код");
                        await App.Current.MainPage.Navigation.PushPopupAsync(pop, true);

                    }
                }
                else
                {
                    CodeSent = await _accountService.SendOtpCodeAsync(PhoneNumber);

                    if (!CodeSent)
                        return;

                    _codeRequested = true;
                    ButtonText = "Подтвердить";
                }
            }
            else
            {
                var pop = new MessageBoxPage("Ошибка!", "Введите телефон");
                await App.Current.MainPage.Navigation.PushPopupAsync(pop, true);
            }

        }
    }
}
