using LearnApp.Models;
using LearnApp.PageModels.Base;
using LearnApp.PageModels.Data;
using LearnApp.Pages;
using LearnApp.Services;
using LearnApp.Services.Navigation;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace LearnApp.PageModels
{
    public class TestsPageModel : PageModelBase
    {
        #region Properties

        private readonly GameManager _game;

        private string _title;
        private INavigationService _navigationService;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand StartCommand { get; private set; }

        #endregion
        public ObservableRangeCollection<Test> Test { get; set; }
        public ObservableRangeCollection<Grouping<string, Test>> TestGroups { get; }

        public AsyncCommand RefreshCommand { get; }

        public AsyncCommand<Test> FavoriteCommand { get; }
        public AsyncCommand<object> SelectedCommand { get; }

        public Command LoadMoreCommand { get; }
        public Command DelayLoadMoreCommand { get; }
        public Command ClearCommand { get; }

        public TestsPageModel()
        {

            Title = "Title H1";

            Test = new ObservableRangeCollection<Test>();
            TestGroups = new ObservableRangeCollection<Grouping<string, Test>>();

            LoadMore();

            RefreshCommand = new AsyncCommand(Refresh);
            FavoriteCommand = new AsyncCommand<Test>(Favorite);
            SelectedCommand = new AsyncCommand<object>(Selected);
            LoadMoreCommand = new Command(LoadMore);
            ClearCommand = new Command(Clear);
            DelayLoadMoreCommand = new Command(DelayLoadMore);

        }
        public TestsPageModel(INavigationService navigationService, GameManager game)
        {
            _navigationService = navigationService;

            Title = "Title H1";

            Test = new ObservableRangeCollection<Test>();
            TestGroups = new ObservableRangeCollection<Grouping<string, Test>>();

            LoadMore();

            RefreshCommand = new AsyncCommand(Refresh);
            FavoriteCommand = new AsyncCommand<Test>(Favorite);
            SelectedCommand = new AsyncCommand<object>(Selected);
            LoadMoreCommand = new Command(LoadMore);
            ClearCommand = new Command(Clear);
            DelayLoadMoreCommand = new Command(DelayLoadMore);
            _game = game;

            StartCommand = new DelegateCommand(OnStartClick);
        }

        public override async  Task InitializeAsync(object navigationDate = null)
        {
        }

        private async void OnStartClick()
        {
           
        }

        async Task Favorite(Test test)
        {
            if (test == null)
                return;


        }

        Test selectedTest;
        public Test SelectedTest
        {
            get => selectedTest;
            set => SetProperty(ref selectedTest, value);
        }

        async Task Selected(object args)
        {
            var test = args as Test;
            if (test == null)
                return;

            SelectedTest = null;
            await App.Current.MainPage.Navigation.PushAsync(new NavigationPage(new LearnApp.Pages.QuizPageBegin(ref test)));

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

            Test.Clear();
            LoadMore();

            IsRefreshing = false;
        }
        
        async void LoadMore()
        {

            Test = await TetsData.GetDataAsync();
            TestGroups.Clear();

            TestGroups.Add(new Grouping<string, Test>("Глава 2", Test.Where(c => c.Chapter == "Глава 2")));
        }

        void DelayLoadMore()
        {
            LoadMore();
        }


        void Clear()
        {
            Test.Clear();
            TestGroups.Clear();
        }
    }
}
