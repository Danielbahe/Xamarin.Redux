namespace AppSample.Views
{
    using AppSample.Actions;
    using AppSample.Services;
    using Xamarin.Redux;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using Xamarin.Forms;
    using AppSample.Models;
    using AppSample.ViewModels;

    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ReduxPage<AppState>
    {
        public List<Item> Items { get; set; }

        public ItemsPage(Store<AppState> store) : base(store)
        {
            InitializeComponent();
            ItemsListView.RefreshCommand = new Command(Refresh);
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;
            //Store.Dispatch(new ResetList());
            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            var data = DependencyService.Get<IDataStore<Item>>();
            var items = data.GetItemsAsync().ToList();
            Store.Dispatch(new InitializeItems(items));
            ItemsListView.ItemsSource = Store.State.Items;
            base.OnAppearing();
        }

        public void Refresh()
        {
            OnStateChanged();
            ItemsListView.IsRefreshing = false;
        }

        protected override void OnStateChanged()
        {
            ItemsListView.ItemsSource = Store.State.Items;
        }
    }
}