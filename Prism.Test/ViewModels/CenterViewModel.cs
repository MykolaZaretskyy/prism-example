using Prism.Mvvm;

namespace Prism.Test
{
    public class CenterViewModel : BindableBase, ICenterViewModel
    {
        private string _centerText = string.Empty;

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
