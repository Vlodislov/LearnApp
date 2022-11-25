using LearnApp.Models;
using LearnApp.PageModels.Base;
using LearnApp.Pages;
using LearnApp.Services;
using LearnApp.Services.Account;
using LearnApp.Services.Navigation;
using LearnApp.Services.Register;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace LearnApp.PageModels
{
    public class RegisterPageModel : PageModelBase
    {
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

        private string _passwordTwo;

        public string PasswordTwo
        {
            get => _passwordTwo;
            set => SetProperty(ref _passwordTwo, value);
        }


        private ICommand _registerInCommand;
        public ICommand RegisterInCommand
        {
            get => _registerInCommand;
            set => SetProperty(ref _registerInCommand, value);
        }

        private INavigationService _navigationService;
        private IRegisterService _registerService;

        public RegisterPageModel(INavigationService navigationService, IRegisterService registerService)
        {
            _navigationService = navigationService;
            _registerService = registerService;
            _registerInCommand = new Command(RegisterIn);
        }
        public override async Task InitializeAsync(object navigationDate)
        {
            await base.InitializeAsync(navigationDate);
        }

        private async void RegisterIn(object obj)
        {
            if (!(Email is null) && !(Password is null))
            {
                if (Password == PasswordTwo)
                {
                    var registerAttempt = await _registerService.RegisterAsync(Email, Password);
                    if (registerAttempt)
                    {
                        var item1 = await PageModelLocator.Resolve<IRepositoryLectures<DataLectures>>().Save(new DataLectures
                        {
                            Lecture1_test = "0",
                            Lecture2_test = "0",
                            Lecture3_test = "0",
                            Lecture4_test = "0",
                            Lecture5_test = "0",
                            Lecture6_test = "0",
                            Lecture7_test = "0",
                            Lecture8_test = "0",
                            Lecture9_test = "0",
                            Lecture10_test = "0",
                            Lecture1_comp = "red",
                            Lecture2_comp = "red",
                            Lecture3_comp = "red",
                            Lecture4_comp = "red",
                            Lecture5_comp = "red",
                            Lecture6_comp = "red",
                            Lecture7_comp = "red",
                            Lecture8_comp = "red",
                            Lecture9_comp = "red",
                            Lecture10_comp = "red"
                        });
                        var item2 = await PageModelLocator.Resolve<IRepositoryTests<DataTests>>().Save(new DataTests
                        {
                            Test1 = "0",
                            Test2 = "0",
                            Test3 = "0",
                            Test4 = "0",
                            Test5 = "0",
                            Test6 = "0",
                            Test7 = "0",
                            Test8 = "0",
                            Test9 = "0",
                            Test10 = "0",
                            Task1_comp = "red",
                            Task2_comp = "red",
                            Task3_comp = "red",
                            Task4_comp = "red",
                            Task5_comp = "red"

                        });
                        var item3 = await PageModelLocator.Resolve<IRepositoryTask<DataTask>>().Save(new DataTask
                        {
                            Task1 = "0",
                            Task2 = "0",
                            Task3 = "0",
                            Task4 = "0",
                            Task5 = "0",
                            Task6 = "0",
                            Task7 = "0",
                            Task8 = "0",
                            Task9 = "0",
                            Task10 = "0",
                            Task1_comp = "red",
                            Task2_comp = "red",
                            Task3_comp = "red",
                            Task4_comp = "red",
                            Task5_comp = "red",
                            Task1_answer = "",
                            Task2_answer = "",
                            Task3_answer = "",
                            Task4_answer = "",
                            Task5_answer = "",

                        });
                        var pop = new MessageBoxPage("Почта", "Мы отправили вам письмо на почту");
                        await App.Current.MainPage.Navigation.PushPopupAsync(pop, true);
                        _registerService.SendEmail();
                        await App.Current.MainPage.Navigation.PopAsync();
                    }
                    else
                    {
                        var pop = new MessageBoxPage("Ошибка!", "Произошла ОШИБКА Регистрации");
                        await App.Current.MainPage.Navigation.PushPopupAsync(pop, true);
                    }
                }
                else
                {
                    var pop = new MessageBoxPage("Ошибка!", "Пароли не совпадают");
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
