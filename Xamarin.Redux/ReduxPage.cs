namespace Xamarin.Redux
{
    using Forms;

    public abstract class ReduxPage<T> : ContentPage where T : class
    {
        protected Store<T> Store;

        protected ReduxPage(Store<T> store)
        {
            Store = store;
        }

        protected override void OnAppearing()
        {
            MessagingCenter.Subscribe<Store<T>>(this, Store.StateUpdatedEventName, (store) => OnStateChanged());
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<Store<T>>(this, Store.StateUpdatedEventName);
            base.OnDisappearing();
        }

        protected abstract void OnStateChanged();
    }
}