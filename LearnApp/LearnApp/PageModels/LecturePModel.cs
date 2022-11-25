using LearnApp.PageModels.Base;
using LearnApp.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LearnApp.PageModels
{
    public class LecturePModel : PageModelBase
    {
        private ICommand _goTestCommand;
        public ICommand GoTestCommand
        {
            get => _goTestCommand;
            set => SetProperty(ref _goTestCommand, value);
        }

        private INavigationService _navigationService;

        public LecturePModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _goTestCommand = new Command(GoTest);
        }

        private async void GoTest(object obj)
        {
            try
            {
                await _navigationService.NavigateToAsync<QuizPageModel>();
            }
            catch (System.Exception ex)
            {
            }
            // await App.Current.MainPage.Navigation.PushAsync(new NavigationPage(new LearnApp.Pages.LectureP(test.Discription)));
            //await Application.Current.MainPage.DisplayAlert("Selected", lecture.Title, "OK");

            // Application.Current.MainPage.DisplayAlert("Инфа", "Здесь будет страница тестов", "OK");
        }
    }
}
