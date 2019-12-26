namespace Xamarin.Redux
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Forms;

    public class Store<T> where T : class
    {
        public T State { get; private set; }
        public string StateUpdatedEventName { get; private set; }
        private Reducer<T> _reducer;
        private readonly List<Effects> _effects;

        private Store(Reducer<T> reducer, string stateUpdatedEventName)
        {
            _effects = new List<Effects>();
            _reducer = reducer;
            StateUpdatedEventName = stateUpdatedEventName;
        }

        public static Store<T> Create(Reducer<T> reducer, string stateUpdatedEventName = "AppStateUpdated")
        {
            var store = new Store<T>(reducer, stateUpdatedEventName);
            store.State = Activator.CreateInstance<T>();

            return store;
        }

        public static Store<T> Create(Reducer<T> reducer, T initialState, string stateUpdatedEventName = "AppStateUpdated")
        {
            var store = new Store<T>(reducer, stateUpdatedEventName);
            store.State = initialState;

            return store;
        }

        public TSubState Select<TSubState> (Selector<TSubState, T> selector) where TSubState : class
        {
            return selector.Select(State);
        }

        public void Dispatch(ReduxAction action)
        {
            var nextAction = UseEffect(action);
            var newState =_reducer.Reduce(State, nextAction);
            State = newState;
            MessagingCenter.Send(this, StateUpdatedEventName);
        }

        public Store<T> RegisterEffects(Effects effects)
        {
            _effects.Add(effects);
            return this;
        }

        public Store<T> RegisterEffects(List<Effects> effects)
        {
            _effects.AddRange(effects);
            return this;
        }
        public Store<T> RegisterReducer(Reducer<T> reducer)
        {
            _reducer = reducer;
            return this;
        }

        private ReduxAction UseEffect(ReduxAction action)
        {
            var module = _effects.FirstOrDefault(e => e.EffectsRegistry.ContainsKey(action.GetType()));
            if (module == null)
            {
                return action;
            }

            var effect = module.EffectsRegistry[action.GetType()];
            var nextAction = effect.Invoke(action);
            return nextAction;
        }
    }
}
