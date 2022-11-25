using LearnApp.PageModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearnApp.Services.Navigation
{
    public interface INavigationService
    {
        /// <summary>
        /// Метод навигации выбрасывает страницы наверх стека
        /// </summary>
        /// <typeparam name="TPageModelBase"></typeparam>
        /// <param name="navigationData"></param>
        /// <param name="setRoot"></param>
        /// <returns></returns>
        Task NavigateToAsync<TPageModelBase>(object navigationData = null, bool setRoot = false) where TPageModelBase : PageModelBase;
        /// <summary>
        /// Метод навигации удаляет последнюю страницу из стека
        /// </summary>
        /// <returns></returns>
        Task GoBackAsync();
    }
}
