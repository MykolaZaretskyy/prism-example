using Prism.Test.Models.Abstract;
using Prism.Test.Models.Items;

namespace Prism.Test.Managers.Abstract
{
    public interface ICategoriesManager
    {
        void OnCategorySelected(CategoryItemModel category);
        void OnFocusedItemChanged(MultiStateItemModel listItem);
        void OnMenuOptionCheckedChanged(MenuOptionItemModel listItem);
    }
}