using Prism.Test.Models.Abstract;
using Prism.Test.Models.Items;

namespace Prism.Test.Managers.Abstract
{
    public interface ICategoriesManager
    {
        void OnCategorySelected(CategoryItemModel category);
        void OnSubCategorySelected(CategoryItemModel subCategory);
        void OnMenuOptionCheckedChanged(MenuOptionItemModel menuOption);
        void OnBackNavigation();
    }
}