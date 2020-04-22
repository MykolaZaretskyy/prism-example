using System.Collections.Generic;
using System.Linq;
using Prism.Mvvm;
using Prism.Test.Models.Abstract;
using Prism.Test.Models.Items;

namespace Prism.Test.Models
{
    public class CategoriesModel : BindableBase, ICategoriesModel
    {
        private CategoryItemModel _selectedCategory;
        private CategoryItemModel _selectedSubCategory;
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

        public IList<CategoryItemModel> SubCategories => SelectedCategory?.SubCategories;

        public IList<MenuOptionItemModel> MenuOptions => SelectedCategory?.MenuOptions;

        public IList<object> CategoryItems => GetCategoryItems().ToList();
        
        public CategoryItemModel SelectedSubCategory
        {
            get => _selectedSubCategory;
            set => SetProperty(ref _selectedSubCategory, value);
        }

        private IEnumerable<object> GetCategoryItems()
        {
            foreach (var subCategory in SubCategories)
            {
                yield return subCategory;
            }

            foreach (var menuOption in MenuOptions)
            {
                yield return menuOption;
            }
        }
    }
}
