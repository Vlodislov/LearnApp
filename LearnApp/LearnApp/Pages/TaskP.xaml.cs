using LearnApp.Models;
using LearnApp.PageModels.Base;
using LearnApp.Services;
using Rg.Plugins.Popup.Extensions;
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
    public partial class TaskP : ContentPage
    {
        Task_ _ts;

        public TaskP(ref Task_ ts)
        {
            _ts = ts;
            InitializeComponent();
            text.Text = _ts.TextTask;
            edit.Text = _ts.AnswerText;
        }


        private async void btn_Clicked(object sender, EventArgs e)
        {
            char[] charsToTrim = { ' ', '\t', '\n' };
            if (!(edit.Text is null))
            {
                if (_ts.Aswer.Replace(" ", "").ToLower() == edit.Text.Replace(" ", "").ToLower())
                {
                    switch (_ts.TaskNumber)
                    {
                        case "1":
                            var item1 = await PageModelLocator.Resolve<IRepositoryTask<DataTask>>()
                                            .Update(new DataTask
                                            {
                                                Task1_comp = "green",
                                                Task1_answer = edit.Text
                                            });
                            break;
                        case "2":
                            var item2 = await PageModelLocator.Resolve<IRepositoryTask<DataTask>>()
                                            .Update(new DataTask
                                            {
                                                Task2_comp = "green",
                                                Task2_answer = edit.Text
                                            });
                            break;
                        case "3":
                            var item3 = await PageModelLocator.Resolve<IRepositoryTask<DataTask>>()
                                            .Update(new DataTask
                                            {
                                                Task3_comp = "green",
                                                Task3_answer = edit.Text
                                            });
                            break;
                        case "4":
                            var item4 = await PageModelLocator.Resolve<IRepositoryTask<DataTask>>()
                                            .Update(new DataTask
                                            {
                                                Task4_comp = "green",
                                                Task4_answer = edit.Text
                                            });
                            break;
                        case "5":
                            var item5 = await PageModelLocator.Resolve<IRepositoryTask<DataTask>>()
                                            .Update(new DataTask
                                            {
                                                Task5_comp = "green",
                                                Task5_answer = edit.Text
                                            });
                            break;
                    }
                    btn.TextColor = Color.LightGreen;
                    var pop = new MessageBoxPage("", "Верно");
                    await App.Current.MainPage.Navigation.PushPopupAsync(pop, true);

                }
                else
                {
                    switch (_ts.TaskNumber)
                    {
                        case "1":
                            var item1 = await PageModelLocator.Resolve<IRepositoryTask<DataTask>>()
                                            .Update(new DataTask
                                            {
                                                Task1_comp = "red",
                                                Task1_answer = edit.Text
                                            });
                            break;
                        case "2":
                            var item2 = await PageModelLocator.Resolve<IRepositoryTask<DataTask>>()
                                            .Update(new DataTask
                                            {
                                                Task2_comp = "red",
                                                Task2_answer = edit.Text
                                            });
                            break;
                        case "3":
                            var item3 = await PageModelLocator.Resolve<IRepositoryTask<DataTask>>()
                                            .Update(new DataTask
                                            {
                                                Task3_comp = "red",
                                                Task3_answer = edit.Text
                                            });
                            break;
                        case "4":
                            var item4 = await PageModelLocator.Resolve<IRepositoryTask<DataTask>>()
                                            .Update(new DataTask
                                            {
                                                Task4_comp = "red",
                                                Task4_answer = edit.Text
                                            });
                            break;
                        case "5":
                            var item5 = await PageModelLocator.Resolve<IRepositoryTask<DataTask>>()
                                            .Update(new DataTask
                                            {
                                                Task5_comp = "red",
                                                Task5_answer = edit.Text
                                            });
                            break;
                    }
                    btn.TextColor = Color.Red;
                    var pop = new MessageBoxPage("", "Неверно");
                    await App.Current.MainPage.Navigation.PushPopupAsync(pop, true);
                }
            }
            else
            {
                var pop = new MessageBoxPage("Ошибка!", "Поле пустое!");
                await App.Current.MainPage.Navigation.PushPopupAsync(pop, true);

            }

        }
    }
}