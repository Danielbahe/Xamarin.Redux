namespace AppSample.Actions
{
    using AppSample.Models;
    using System.Collections.Generic;
    using Xamarin.Redux;
    public class InitializeItems : ReduxAction
    {
        public List<Item> Items { get; set; }

        public InitializeItems(List<Item> items)
        {
            Items = items;
        }
    }
}
