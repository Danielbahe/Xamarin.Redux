namespace AppSample
{
    using System;
    using Actions;
    using Models;
    using Xamarin.Redux;

    public class CustomReducer : Reducer<AppState>
    {
        public override AppState Reduce(AppState state, ReduxAction action)
        {
            if (action.GetType() == typeof(CustomAction))
            {
                return new AppState();
            }

            throw new NotImplementedException();
        }
    }
}