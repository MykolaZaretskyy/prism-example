using Prism.Mvvm;
using Prism.Test.ViewModels.Abstract;

namespace Prism.Test.ViewModels
{
    public class CenterViewModel : BindableBase, ICenterViewModel
    {
        private string _centerText = "Initial text";

        public CenterViewModel()
        {
        }

        public string CenterText
        {
            get => _centerText;
            set => SetProperty(ref _centerText, value);
        }
    }
}
