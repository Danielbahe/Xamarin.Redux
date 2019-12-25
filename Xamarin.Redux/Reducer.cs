namespace Xamarin.Redux
{
    public abstract class Reducer<T> where T: class
    {
        public abstract T Reduce(T state, ReduxAction action);
    }
}
