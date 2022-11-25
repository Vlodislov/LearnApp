using LearnApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearnApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LectureP : ContentPage
    {
        Lecture _lecture;
        public LectureP(ref Lecture lec)
        {
            _lecture = lec;
            InitializeComponent();
            label1.Text = lec.Discription1;
            image1.Source = lec.Image1;
            label2.Text = lec.Discription2;
            image2.Source = lec.Image2;
            zag.Text = lec.Title;
            glav.Text = lec.Chapter;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            
                try
                {
                
                await App.Current.MainPage.Navigation.PushAsync(new NavigationPage(new Page1(_lecture)));
                }
                catch (System.Exception ex)
                {
                }
                // await App.Current.MainPage.Navigation.PushAsync(new NavigationPage(new LearnApp.Pages.LectureP(test.Discription)));
                //await Application.Current.MainPage.DisplayAlert("Selected", lecture.Title, "OK");

                // Application.Current.MainPage.DisplayAlert("Инфа", "Здесь будет страница тестов", "OK");
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            Uri uri = new Uri($"{_lecture.VideoLink}");
            await Browser.OpenAsync(uri);
        }
    }
}