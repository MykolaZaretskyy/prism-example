using System.Collections.Generic;
using System.Linq;
using Prism.Test.Managers.Abstract;
using Prism.Test.Models.Abstract;
using Prism.Test.Models.Items;

namespace Prism.Test.Managers
{
    public class CategoriesManager : ICategoriesManager
    {
        private readonly ICategoriesModel _categoriesModel;
        private readonly IYourOrderModel _yourOrderModel;
        private readonly Stack<CategoryItemModel> _subCategoriesNavigationStack;

        public CategoriesManager(ICategoriesModel categoriesModel, IYourOrderModel yourOrderModel)
        {
            _categoriesModel = categoriesModel;
            _yourOrderModel = yourOrderModel;
            _subCategoriesNavigationStack = new Stack<CategoryItemModel>();
        }

        public void OnCategorySelected(CategoryItemModel category)
        {
            CategorySelectedImpl(_categoriesModel.SelectedCategory, category);
            _categoriesModel.SetSelectedSubCategory(null, false);
            _categoriesModel.SetSelectedCategory(category);
        }

        public void OnSubCategorySelected(CategoryItemModel subCategory)
        {
            if (_categoriesModel.SelectedSubCategory != null)
            {
                _subCategoriesNavigationStack.Push(_categoriesModel.SelectedSubCategory);
            }
            
            _categoriesModel.SetSelectedSubCategory(subCategory);
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

        public void OnBackNavigation()
        {
            var selectedSubCategory = _subCategoriesNavigationStack.Any()
                ? _subCategoriesNavigationStack.Pop()
                : null;
            _categoriesModel.SetSelectedSubCategory(selectedSubCategory);
        }

        private void CategorySelectedImpl(CategoryItemModel previousSelectedCategory, CategoryItemModel newSelectedCategory)
        {
            previousSelectedCategory?.RemoveState(ListItemState.Selected);
            newSelectedCategory.AddState(ListItemState.Selected);
        }
    }
}