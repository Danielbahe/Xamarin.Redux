namespace AppSample
{
    using System;
    using System.Collections.Generic;
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
            else if (action.GetType() == typeof(ResultAction))
            {
                return new AppState();
            }
            else if (action.GetType() == typeof(ResetList))
            {
                var newState =  new AppState();
                newState = state;
                newState.Items = new List<Item>();
                return newState;
            }
            else if (action.GetType() == typeof(InitializeItems))
            {
                var initializeAction = (InitializeItems)action;

                var newState = new AppState();
                newState = state;
                newState.Items = new List<Item>(initializeAction.Items);
                return newState;
            }

            throw new NotImplementedException();
        }
    }
}