namespace Xamarin.Redux
{
    public class Store<T> where T : class
    {
        public T State { get; private set; }
        private Reducer<T> reducer;

        private Store()
        {

        }

        public static Store<T> Create()
        {
            return new Store<T>();
        }

        public static Store<T> Create(T initialState)
        {
            var store = new Store<T>();
            store.State = initialState;

            return store;
        }

        public TSubState Select<TSubState> (Selector<TSubState, T> selector) where TSubState : class
        {
            return selector.SelectorFunction.Invoke(State);
        }

        public void Dispatch(ReduxAction action)
        {
            reducer.Reduce(State, action);
        }
    }
}
