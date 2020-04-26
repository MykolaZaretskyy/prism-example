using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Prism.Test.Views.Controls
{
    public class CustomListView : ListView
    {
        public static readonly BindableProperty ItemSelectedCommandProperty =
            BindableProperty.Create(nameof(ItemSelectedCommand), typeof(ICommand), typeof(CustomListView));

        public CustomListView()
        {
            ItemTapped += (s, e) => ItemSelectedCommand?.Execute(e.Item);
        }

        public ICommand ItemSelectedCommand
        {
            get => (ICommand)GetValue(ItemSelectedCommandProperty);
            set => SetValue(ItemSelectedCommandProperty, value);
        }
    }
}
