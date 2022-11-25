using LearnApp.PageModels;
using LearnApp.PageModels.Base;
using LearnApp.Services.Navigation;
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
    public partial class ChoicePage : ContentPage
    {
      
        public bool IsLogedIn { get; set; }

        public ChoicePage()
        {
            
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var navService = PageModelLocator.Resolve<INavigationService>();
            navService.NavigateToAsync<RegisterPageModel>();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {

        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            var nav = App.Current.MainPage as Xamarin.Forms.NavigationPage;
            nav.BarBackgroundColor = Color.FromRgb(120, 35, 121);
            nav.BarTextColor = Color.White;
            nav.PushAsync(new NavigationPage(new LearnApp.Pages.LoginPage()));
        }
    }
}