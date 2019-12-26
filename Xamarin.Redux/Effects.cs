namespace Xamarin.Redux
{
    using System;
    using System.Collections.Generic;

    public abstract class Effects {

        public Dictionary<Type, Func<ReduxAction, ReduxAction>> EffectsRegistry { get; protected set; }
    }
}
