using Prism.Mvvm;
using Prism.Test.ViewModels.Abstract;

namespace Prism.Test.ViewModels
{
    public class RightViewModel : BindableBase, IRightViewModel
    {
        private string _rightText;

        public RightViewModel()
        {
        }

        public string RightText
        {
            get => _rightText;
            set => SetProperty(ref _rightText, value);
        }
    }
}
