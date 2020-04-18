using Xamarin.Forms;

namespace Prism.Test.Views
{
    public partial class MenuOrderingPage
    {
        public MenuOrderingPage()
        {
            InitializeComponent();
        }

        private void CheckBox_OnCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var checkbox = (CheckBox) sender;
            var menuOption = checkbox.BindingContext;
            CategoryItemsList.ItemCheckedCommand?.Execute(menuOption);
        }
    }
}
