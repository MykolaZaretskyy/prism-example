using Prism.Mvvm;

namespace Prism.Test
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
