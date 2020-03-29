using Prism.Navigation;

namespace Prism.Test
{
    public class HomeViewModel : ViewModelBase
    {
        public HomeViewModel(INavigationService navigationService) : base(navigationService)
        {
            LeftViewModel = new LeftViewModel();
            CenterViewModel = new CenterViewModel();
            RightViewModel = new RightViewModel();
        }

        public LeftViewModel LeftViewModel { get; }

        public CenterViewModel CenterViewModel { get; }

        public RightViewModel RightViewModel { get; }
    }
}
