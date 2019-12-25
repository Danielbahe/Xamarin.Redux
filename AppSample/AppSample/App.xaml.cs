using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppSample.Services;
using AppSample.Views;
using AppSample.Models;
using Xamarin.Redux;
using AppSample.Actions;

namespace AppSample
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            SetupState();

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
        }

        private static void SetupState()
        {
            var appStore = Store<AppState>.Create();
            var appState = appStore.State;

            var selector = new Selector<Item, AppState>((state) => state.CustomSubState);
            var subState = appStore.Select<Item>(selector);

            appStore.Dispatch(new CustomAction());
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
