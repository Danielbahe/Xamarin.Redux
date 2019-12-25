using System;

namespace Xamarin.Redux
{
    public abstract class ReduxAction
    {
        public string Type { get; protected set; }
        public Type Effect { get; protected set; }
    }
}
