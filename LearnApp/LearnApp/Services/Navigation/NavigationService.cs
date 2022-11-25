using LearnApp.PageModels.Base;
using LearnApp.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LearnApp.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        public Task GoBackAsync()
        {
            return App.Current.MainPage.Navigation.PopAsync();
        }
        public async Task NavigateToAsync<TPageModelBase>(object navigationData = null, bool setRoot = false) where TPageModelBase : PageModelBase
        {
            var page = PageModelLocator.CreatePageFor(typeof(TPageModelBase));
            
            if (setRoot)
            {
                if (page is TabbedPage tabbedPage)
                {
                    App.Current.MainPage = new NavigationPage(tabbedPage);
                }
                else
                {
                    App.Current.MainPage = new NavigationPage(page);
                }
            }
            else
            {
                if (page is TabbedPage tabbedPage)
                {
                    App.Current.MainPage = new NavigationPage(tabbedPage);
                }
                else
                if (App.Current.MainPage is NavigationPage navPage)
                {
                    await navPage.PushAsync(page);
                }
                else
                {
                    App.Current.MainPage = new NavigationPage(page);
                }
            }
            if (page.BindingContext is PageModelBase pmBase)
            {
                await pmBase.InitializeAsync(navigationData); // Ждем инициализации страницы
            }

        }
    }
}
