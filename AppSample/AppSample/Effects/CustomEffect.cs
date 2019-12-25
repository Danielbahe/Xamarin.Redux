namespace AppSample.Effects
{
    using AppSample.Actions;
    using Xamarin.Redux;

    public class CustomEffect : IEffect
    {
        public void Execute()
        {
            // do some stuff
            var isOk = true;

            if (isOk)
            {
                OnSuccess();
            }
            else
            {
                OnError();
            }
        }

        public ReduxAction OnError()
        {
            //parse error or whatever
            return new CustomAction();
        }

        public ReduxAction OnSuccess()
        {
            //parse result or whatever
            return new CustomAction();
        }
    }
}
