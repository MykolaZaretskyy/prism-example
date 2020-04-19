using Prism.Navigation;
using Prism.Test.Managers.Abstract;
using Prism.Test.Models.Abstract;
using Prism.Test.ViewModels.Abstract;

namespace Prism.Test.ViewModels
{
    public class MenuOrderingPageViewModel : ViewModelBase
    {
        public MenuOrderingPageViewModel(INavigationService navigationService, ICategoriesModel categoriesModel,
            ICategoryItemsModel categoryItemsModel, IYourOrderModel yourOrderModel,
            ICategoriesManager categoriesManager) : base(navigationService)
        {
            CategoriesViewModel = new CategoriesViewModel(categoriesModel, categoriesManager);
            CategoryItemsViewModel = new CategoryItemsViewModel(categoriesModel, categoriesManager);
            YourOrderViewModel = new YourOrderViewModel(yourOrderModel);
        }

        public CategoriesViewModel CategoriesViewModel { get; }

        public CategoryItemsViewModel CategoryItemsViewModel { get; }

        public YourOrderViewModel YourOrderViewModel { get; }
    }
}
