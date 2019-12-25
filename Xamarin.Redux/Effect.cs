namespace Xamarin.Redux
{
    public interface IEffect
    {
        void Execute();
        ReduxAction OnSuccess();
        ReduxAction OnError();
    }

    public abstract class Effect<T>: IEffect where T: ReduxAction
    {
        private readonly T _action;

        public Effect()
        {

        }

        public Effect(T action)
        {
            _action = action;
        }

        public abstract void Execute();

        public abstract ReduxAction OnError();

        public abstract ReduxAction OnSuccess();
    }
}
