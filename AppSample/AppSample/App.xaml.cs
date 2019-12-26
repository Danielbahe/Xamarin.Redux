namespace AppSample
{
    using Xamarin.Forms;
    using AppSample.Services;
    using AppSample.Views;
    using AppSample.Models;
    using Xamarin.Redux;
    using AppSample.Actions;

    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var appStore = SetupState();

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage(appStore);
        }

        private Store<AppState> SetupState()
        {
            var appStore = Store<AppState>.Create(new CustomReducer());
            var appState = appStore.State;

            var selector = new CustomSelector();
            var subState = appStore.Select(selector);

            appStore.Dispatch(new CustomAction());

            return appStore;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}