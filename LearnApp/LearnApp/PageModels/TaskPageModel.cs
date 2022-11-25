using LearnApp.Models;
using LearnApp.PageModels.Base;
using LearnApp.Services.Navigation;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;
using System.IO;
using System;
using LearnApp.Services.Account;
using LearnApp.Services;
using LearnApp.PageModels.Data;

namespace LearnApp.PageModels
{
    public class TaskPageModel : PageModelBase
    {
        public ObservableRangeCollection<Task_> Task_ { get; set; }
        public ObservableRangeCollection<Grouping<string, Task_>> TaskGroups { get; }

        public AsyncCommand RefreshCommand { get; }

        public AsyncCommand<Task_> FavoriteCommand { get; }
        public AsyncCommand<object> SelectedCommand { get; }

        public Command LoadMoreCommand { get; }
        public Command DelayLoadMoreCommand { get; }
        public Command ClearCommand { get; }

        public TaskPageModel()
        {

            Title = "Title H1";

            Task_ = new ObservableRangeCollection<Task_>();
            TaskGroups = new ObservableRangeCollection<Grouping<string, Task_>>();

            LoadMore();

            RefreshCommand = new AsyncCommand(Refresh);
            FavoriteCommand = new AsyncCommand<Task_>(Favorite);
            SelectedCommand = new AsyncCommand<object>(Selected);
            LoadMoreCommand = new Command(LoadMore);
            ClearCommand = new Command(Clear);
            DelayLoadMoreCommand = new Command(DelayLoadMore);

        }

        private IAccountService _accountService;
        private INavigationService _navigationService;

        public TaskPageModel(INavigationService navigationService, IAccountService accountService)
        {

            _navigationService = navigationService;
            _accountService = accountService;
            Title = "Title H1";

            Task_ = new ObservableRangeCollection<Task_>();
            TaskGroups = new ObservableRangeCollection<Grouping<string, Task_>>();

            LoadMore();

            RefreshCommand = new AsyncCommand(Refresh);
            FavoriteCommand = new AsyncCommand<Task_>(Favorite);
            SelectedCommand = new AsyncCommand<object>(Selected);
            LoadMoreCommand = new Command(LoadMore);
            ClearCommand = new Command(Clear);
            DelayLoadMoreCommand = new Command(DelayLoadMore);
        }


        async Task Favorite(Task_ lecture)
        {
            if (lecture == null)
                return;


        }

        Task_ selectedTask;
        public Task_ SelectedTask
        {
            get => selectedTask;
            set => SetProperty(ref selectedTask, value);
        }

        async Task Selected(object args)
        {
            var task = args as Task_;
            if (task == null)
                return;

            SelectedTask = null;
            await App.Current.MainPage.Navigation.PushAsync(new NavigationPage(new LearnApp.Pages.TaskP(ref task)));

        }

        public bool IsBusy { get; private set; }

        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }


        async Task Refresh()
        {
            IsRefreshing = true;
            await Task.Delay(2000);

            Task_.Clear();
            LoadMore();

            IsRefreshing = false;
        }

        async void LoadMore()
        {
            Task_ = await TaskData.GetDataAsync();
            TaskGroups.Clear();

            TaskGroups.Add(new Grouping<string, Task_>("Глава 2", Task_.Where(c => c.Chapter == "Глава 2")));

        }

        void DelayLoadMore()
        {
            LoadMore();
        }


        void Clear()
        {
            Task_.Clear();
            TaskGroups.Clear();
        }

    }
}
