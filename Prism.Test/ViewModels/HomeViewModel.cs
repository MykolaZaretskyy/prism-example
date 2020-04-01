using Prism.Navigation;
using Prism.Test.ViewModels.Abstract;

namespace Prism.Test.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public HomeViewModel(INavigationService navigationService, ILeftViewModel leftViewModel,
            ICenterViewModel centerViewModel, IRightViewModel rightViewModel) : base(navigationService)
        {
            LeftViewModel = (LeftViewModel) leftViewModel;
            CenterViewModel = (CenterViewModel) centerViewModel;
            RightViewModel = (RightViewModel) rightViewModel;
        }

        public LeftViewModel LeftViewModel { get; }

        public CenterViewModel CenterViewModel { get; }

        public RightViewModel RightViewModel { get; }
    }
}
