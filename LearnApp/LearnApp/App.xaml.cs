using LearnApp.PageModels;
using LearnApp.PageModels.Base;
using LearnApp.Services.Navigation;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("PressStart2P-Regular.ttf", Alias = "Press")]

namespace LearnApp
{
    public partial class App : Application
    {
        public App()
        {
            Sharpnado.Shades.Initializer.Initialize(loggerEnable: false);
            InitializeComponent();
        }
        Task InitNavigation()
        {
            var navService = PageModelLocator.Resolve<INavigationService>();
            return navService.NavigateToAsync<BeginPageModel>();
        }
        protected async override void OnStart()
        {
            await InitNavigation();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
