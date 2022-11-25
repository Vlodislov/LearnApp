using LearnApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearnApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuizPageBegin : ContentPage
    {
        Test lecture;
        public QuizPageBegin(ref Test lecture)
        {
            InitializeComponent();
            this.lecture = lecture;
            pre.Text = lecture.Preload;
            kolvo.Text = "Ваш прошлый результат " + lecture.CorrectCount.ToString() + "/10";
        }

        private async void But_Clicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PopAsync();
            await App.Current.MainPage.Navigation.PushAsync(new NavigationPage(new QuizPage(this.lecture)));
        }
    }
}