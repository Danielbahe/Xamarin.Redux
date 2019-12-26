namespace Xamarin.Redux
{
    public abstract class Selector<TSubState, TState> where TState: class where TSubState : class
    {
        public abstract TSubState Select(TState state);
    }
}
