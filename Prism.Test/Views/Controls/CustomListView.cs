using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Prism.Test.Views.Controls
{
    public class CustomListView : ListView
    {
        public static readonly BindableProperty ItemSelectedCommandProperty =
            BindableProperty.Create(nameof(ItemSelectedCommand), typeof(ICommand), typeof(CustomListView));

        public static readonly BindableProperty ItemCheckedCommandProperty =
            BindableProperty.Create(nameof(ItemSelectedCommand), typeof(ICommand), typeof(CustomListView));

        public CustomListView()
        {
            ItemSelected += (s, e) => ItemSelectedCommand?.Execute(e.SelectedItem);
        }

        public ICommand ItemSelectedCommand
        {
            get => (ICommand)GetValue(ItemSelectedCommandProperty);
            set => SetValue(ItemSelectedCommandProperty, value);
        }

        public ICommand ItemCheckedCommand
        {
            get => (ICommand)GetValue(ItemCheckedCommandProperty);
            set => SetValue(ItemCheckedCommandProperty, value);
        }
    }
}
