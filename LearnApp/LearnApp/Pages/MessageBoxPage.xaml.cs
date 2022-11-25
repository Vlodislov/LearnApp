using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
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
    public partial class MessageBoxPage : PopupPage
    {
        public MessageBoxPage(string title, string message)
        {
            InitializeComponent();
            TitleTxt.Text = title;
            MsgTxt.Text = message;
        }

        public EventHandler<DialogResult> OnDialogClosed;
        private void Button_Clicked(object sender, EventArgs e)
        {
            //OnDialogClosed.Invoke(this, new DialogResult { Success = false, Message = "Message" });
            App.Current.MainPage.Navigation.PopPopupAsync(true);
        }
    }

    public class DialogResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}