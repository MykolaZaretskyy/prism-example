using Prism.Navigation;
using Prism.Test.ViewModels.Abstract;

namespace Prism.Test.ViewModels
{
    public class MenuOrderingPageViewModel : ViewModelBase
    {
        public MenuOrderingPageViewModel(INavigationService navigationService, CategoriesViewModel categoriesViewModel,
            CategoryItemsViewModel categoryItemsViewModel,
            YourOrderViewModel yourOrderViewModel) : base(navigationService)
        {
            CategoriesViewModel = categoriesViewModel;
            CategoryItemsViewModel = categoryItemsViewModel;
            YourOrderViewModel = yourOrderViewModel;
        }

        public CategoriesViewModel CategoriesViewModel { get; }

        public CategoryItemsViewModel CategoryItemsViewModel { get; }

        public YourOrderViewModel YourOrderViewModel { get; }
    }
}
