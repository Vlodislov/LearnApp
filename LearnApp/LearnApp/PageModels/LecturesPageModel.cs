using LearnApp.Models;
using LearnApp.PageModels.Base;
using LearnApp.Services.Navigation;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;
using System;
using LearnApp.Services.Account;
using LearnApp.Services;
using LearnApp.PageModels.Data;

namespace LearnApp.PageModels
{
    public class LecturesPageModel : PageModelBase
    {
        public ObservableRangeCollection<Lecture> Lecture { get; set; }
        public ObservableRangeCollection<Grouping<string, Lecture>> LectureGroups { get; }

        public AsyncCommand RefreshCommand { get; }

        public AsyncCommand<Lecture> FavoriteCommand { get; }
        public AsyncCommand<object> SelectedCommand { get; }

        public Command LoadMoreCommand { get; }
        public Command DelayLoadMoreCommand { get; }
        public Command ClearCommand { get; }


        public LecturesPageModel()
        {

            Title = "Title H1";

            Lecture = new ObservableRangeCollection<Lecture>();
            LectureGroups = new ObservableRangeCollection<Grouping<string, Lecture>>();

            LoadMore();

            RefreshCommand = new AsyncCommand(Refresh);
            FavoriteCommand = new AsyncCommand<Lecture>(Favorite);
            SelectedCommand = new AsyncCommand<object>(Selected);
            LoadMoreCommand = new Command(LoadMore);
            ClearCommand = new Command(Clear);
            DelayLoadMoreCommand = new Command(DelayLoadMore);

        }

       

        private IAccountService _accountService;
        private INavigationService _navigationService;

        public LecturesPageModel(INavigationService navigationService, IAccountService accountService)
        {

            _navigationService = navigationService;
            _accountService = accountService;
            Title = "Title H1";

            Lecture = new ObservableRangeCollection<Lecture>();
            LectureGroups = new ObservableRangeCollection<Grouping<string, Lecture>>();

            LoadMore();

            RefreshCommand = new AsyncCommand(Refresh);
            FavoriteCommand = new AsyncCommand<Lecture>(Favorite);
            SelectedCommand = new AsyncCommand<object>(Selected);
            LoadMoreCommand = new Command(LoadMore);
            ClearCommand = new Command(Clear);
            DelayLoadMoreCommand = new Command(DelayLoadMore);
        }

        
        public override async Task InitializeAsync(object navigationDate)
        {
            //User Check
            await base.InitializeAsync(navigationDate);
        }
        async Task Favorite(Lecture lecture)
        {
            if (lecture == null)
                return;

        }

        Lecture selectedLecture;    
        public Lecture SelectedLecture
        {
            get => selectedLecture;
            set => SetProperty(ref selectedLecture, value);
        }

        async Task Selected(object args)
        {
            var lec = args as Lecture;
            if (lec == null)
                return;

            SelectedLecture = null;
            await App.Current.MainPage.Navigation.PushAsync(new NavigationPage(new LearnApp.Pages.LectureP(ref lec)));

        }

        

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

            Lecture.Clear();
            LoadMore();

            IsRefreshing = false;
        }

        async void LoadMore()
        {
            Lecture = await LecturesData.GetDataAsync();

            LectureGroups.Clear();

            LectureGroups.Add(new Grouping<string, Lecture>("Глава 1", Lecture.Where(c => c.Chapter == "Глава 1")));
            LectureGroups.Add(new Grouping<string, Lecture>("Глава 2", Lecture.Where(c => c.Chapter == "Глава 2")));

        }

        void DelayLoadMore()
        {
            LoadMore();
        }


        void Clear()
        {
            Lecture.Clear();
            LectureGroups.Clear();
        }


    }
}
