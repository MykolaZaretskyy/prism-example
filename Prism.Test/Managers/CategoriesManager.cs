using Prism.Test.Managers.Abstract;
using Prism.Test.Models.Abstract;
using Prism.Test.Models.Items;

namespace Prism.Test.Managers
{
    public class CategoriesManager : ICategoriesManager
    {
        private readonly ICategoriesModel _categoriesModel;
        private readonly ICategoryItemsModel _categoryItemsModel;
        private readonly IYourOrderModel _yourOrderModel;

        public CategoriesManager(ICategoriesModel categoriesModel, ICategoryItemsModel categoryItemsModel, IYourOrderModel yourOrderModel)
        {
            _categoriesModel = categoriesModel;
            _categoryItemsModel = categoryItemsModel;
            _yourOrderModel = yourOrderModel;
        }

        public void OnCategorySelected(CategoryItemModel category)
        {
            var selectedCategory = _categoriesModel.SelectedCategory;
            selectedCategory?.RemoveState(ListItemState.Selected);
            category.AddState(ListItemState.Selected);
            _categoriesModel.SelectedCategory = category;
        }

        public void OnFocusedItemChanged(MultiStateItemModel listItem)
        {
            _categoryItemsModel.FocusedItem?.RemoveState(ListItemState.Focused);
            listItem.AddState(ListItemState.Focused);
            _categoryItemsModel.FocusedItem = listItem;
        }

        public void OnMenuOptionCheckedChanged(MenuOptionItemModel listItem)
        {
            if (listItem.State.HasFlag(ListItemState.Selected))
            {
                listItem.RemoveState(ListItemState.Selected);
                _yourOrderModel.RemoveOrderedItem(listItem);
            }
            else
            {
                listItem.AddState(ListItemState.Selected);
                _yourOrderModel.AddOrderedItem(listItem);
            }
        }
    }
}