using Prism.Mvvm;
using Prism.Test.ViewModels.Abstract;

namespace Prism.Test.ViewModels
{
    public class LeftViewModel : BindableBase, ILeftViewModel
    {
        private string _inputText = string.Empty;

        public LeftViewModel()
        {
        }

        public string InputText
        {
            get => _inputText;
            set => SetProperty(ref _inputText, value);
        }

        public string Placeholder { get; } = "My Placeholder";
    }
}
