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
            ItemSelected += (s, e) => ItemSelectedCommand?.Execute(e.SelectedItem);
        }

        public ICommand ItemSelectedCommand
        {
            get => (ICommand)GetValue(ItemSelectedCommandProperty);
            set => SetValue(ItemSelectedCommandProperty, value);
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
        }
    }
}
