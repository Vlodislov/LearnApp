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
    public partial class TestsPage : ContentPage
    {
        public TestsPage()
        {
            InitializeComponent();
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var random = new Random();
            var random1 = (int)random.Next(0, 255);
            var random2 = (int)random.Next(0, 255);
            var random3 = (int)random.Next(0, 255);
            App.Current.Resources["WindowBackgroundColor"] = Color.FromRgb(random1, random2, random3);
        }
    }
}