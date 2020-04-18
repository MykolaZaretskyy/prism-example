using Prism.Navigation;
using Prism.Test.Models.Abstract;
using Prism.Test.ViewModels.Abstract;

namespace Prism.Test.ViewModels
{
    public class MenuOrderingPageViewModel : ViewModelBase
    {
        public MenuOrderingPageViewModel(INavigationService navigationService, ICategoriesModel categoriesModel, ICategoryItemsModel categoryItemsModel) : base(navigationService)
        {
            CategoriesViewModel = new CategoriesViewModel(categoriesModel);
            CategoryItemsViewModel = new CategoryItemsViewModel(categoriesModel, categoryItemsModel);
            YourOrderViewModel = new YourOrderViewModel(categoryItemsModel);
        }

        public CategoriesViewModel CategoriesViewModel { get; }

        public CategoryItemsViewModel CategoryItemsViewModel { get; }

        public YourOrderViewModel YourOrderViewModel { get; }
    }
}
