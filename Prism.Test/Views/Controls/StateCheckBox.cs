using System.Windows.Input;
using Xamarin.Forms;

namespace Prism.Test.Views.Controls
{
    public class StateCheckBox : CheckBox
    {
        public static readonly BindableProperty CheckedChangedCommandProperty =
            BindableProperty.Create(nameof(CheckedChangedCommand), typeof(ICommand), typeof(StateCheckBox));

        public StateCheckBox()
        {
            CheckedChanged += OnCheckedChanged;
        }
        
        public ICommand CheckedChangedCommand
        {
            get => (ICommand)GetValue(CheckedChangedCommandProperty);
            set => SetValue(CheckedChangedCommandProperty, value);
        }

        private void OnCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            CheckedChangedCommand?.Execute(e.Value);
        }
    }
}