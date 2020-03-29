using Prism.Mvvm;

namespace Prism.Test
{
    public class CenterViewModel : BindableBase, ICenterViewModel
    {
        private string _centerText;

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
