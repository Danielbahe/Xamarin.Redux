namespace Xamarin.Redux
{
    using System;
    public class Selector<TSubState, TState> where TState: class where TSubState : class
    {
        public Func<TState, TSubState> SelectorFunction { get; set; }

        public Selector(Func<TState, TSubState> selector)
        {
            SelectorFunction = selector;
        }
    }
}
