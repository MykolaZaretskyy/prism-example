using System.Collections.Generic;
using Prism.Mvvm;
using Prism.Test.Models.Abstract;

namespace Prism.Test.Models
{
    public class CategoriesModel : BindableBase, ICategoriesModel
    {
        private CategoryItemModel _selectedCategory;
        public CategoriesModel()
        {
            Categories = new List<CategoryItemModel>
            {
                new CategoryItemModel("Category 1").PopulateWithData(),
                new CategoryItemModel("Category 2").PopulateWithData(),
                new CategoryItemModel("Category 3").PopulateWithData(),
            };
        }

        public IList<CategoryItemModel> Categories { get; }

        public CategoryItemModel SelectedCategory
        {
            get => _selectedCategory;
            set => SetProperty(ref _selectedCategory, value);
        }

        public void OnCategorySelected(CategoryItemModel category)
        {
            if (SelectedCategory != null)
            {
                SelectedCategory.State = ListItemState.None;
            }

            category.State = ListItemState.Selected;
            SelectedCategory = category;
        }
    }
}
