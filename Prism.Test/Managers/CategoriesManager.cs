using Prism.Test.Managers.Abstract;
using Prism.Test.Models.Abstract;
using Prism.Test.Models.Items;

namespace Prism.Test.Managers
{
    public class CategoriesManager : ICategoriesManager
    {
        private readonly ICategoriesModel _categoriesModel;
        private readonly IYourOrderModel _yourOrderModel;

        public CategoriesManager(ICategoriesModel categoriesModel, IYourOrderModel yourOrderModel)
        {
            _categoriesModel = categoriesModel;
            _yourOrderModel = yourOrderModel;
        }

        public void OnCategorySelected(CategoryItemModel category)
        {
            CategorySelectedImpl(_categoriesModel.SelectedCategory, category);
            _categoriesModel.SelectedCategory = category;
        }

        public void OnSubCategorySelected(CategoryItemModel subCategory)
        {
            CategorySelectedImpl(_categoriesModel.SelectedSubCategory,subCategory);
            _categoriesModel.SelectedSubCategory = subCategory;
        }
        
        public void OnMenuOptionCheckedChanged(MenuOptionItemModel menuOption)
        {
            if (menuOption.State.HasFlag(ListItemState.Selected))
            {
                menuOption.RemoveState(ListItemState.Selected);
                _yourOrderModel.RemoveOrderedItem(menuOption);
            }
            else
            {
                menuOption.AddState(ListItemState.Selected);
                _yourOrderModel.AddOrderedItem(menuOption);
            }
        }

        private void CategorySelectedImpl(CategoryItemModel previousSelectedCategory, CategoryItemModel newSelectedCategory)
        {
            previousSelectedCategory?.RemoveState(ListItemState.Selected);
            newSelectedCategory.AddState(ListItemState.Selected);
        }
    }
}