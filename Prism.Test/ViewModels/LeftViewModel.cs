using Prism.Mvvm;

namespace Prism.Test
{
    public class LeftViewModel : BindableBase, ILeftViewModel
    {
        private string _inputText;

        public LeftViewModel()
        {
        }

        public string InputText
        {
            get => _inputText;
            set => SetProperty(ref _inputText, value);
        }
    }
}
