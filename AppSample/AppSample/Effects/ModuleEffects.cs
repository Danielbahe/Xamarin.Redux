namespace AppSample.Effects
{
    using System;
    using System.Collections.Generic;
    using Actions;
    using Xamarin.Redux;

    public class ModuleEffects : Effects
    {
        public ModuleEffects()
        {
            EffectsRegistry = new Dictionary<Type, Func<ReduxAction, ReduxAction>>
            {
                {typeof(CustomAction), EffectMehtod1 }
            };
        }
        public ReduxAction EffectMehtod1(ReduxAction action)
        {

            // do stuff
            //return result action or error action or whatever
            return new ResultAction();
        }
    }
}