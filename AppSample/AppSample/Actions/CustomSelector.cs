namespace AppSample.Actions
{
    using Models;
    using Xamarin.Redux;

    public class CustomSelector : Selector<Item, AppState>
    {
        public override Item Select(AppState state)
        {
            return state.CustomSubState;
        }
    }
}