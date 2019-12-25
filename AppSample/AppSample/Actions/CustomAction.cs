namespace AppSample.Actions
{
    using Xamarin.Redux;
    public class CustomAction : ReduxAction
    {
        public string Type => "[Test] CustomAction";
        public CustomAction()
        {

        }

    }
}
