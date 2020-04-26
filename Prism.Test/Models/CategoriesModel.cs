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
                new CategoryItemModel("Category 1").PopulateWithData("0"),
                new CategoryItemModel("Category 2").PopulateWithData("1"),
                new CategoryItemModel("Category 3").PopulateWithData("2"),
            };

            foreach (var category in Categories)
            {
                for (var i = 0; i < category.SubCategories.Count; i++)
                {
                    var subCat = category.SubCategories[i];
                    subCat.PopulateWithData($"{i}{i}");
                }
            }
        }

        public IList<CategoryItemModel> Categories { get; }

        public CategoryItemModel SelectedCategory
        {
            get => _selectedCategory;
            private set => SetProperty(ref _selectedCategory, value);
        }
        
        public CategoryItemModel SelectedSubCategory
        {
            get => _selectedSubCategory;
            private set => SetProperty(ref _selectedSubCategory, value);
        }

        public IList<CategoryItemModel> SubCategories => (SelectedSubCategory ?? SelectedCategory).SubCategories;

        public IList<MenuOptionItemModel> MenuOptions => (SelectedSubCategory ?? SelectedCategory)?.MenuOptions;

        public IList<object> CategoryItems => GetCategoryItems().ToList();

        public void SetSelectedCategory(CategoryItemModel selectedCategory)
        {
            SelectedCategory = selectedCategory;
        }
        
        public void SetSelectedSubCategory(CategoryItemModel selectedSubCategory, bool notifyPropertyChanged = true)
        {
            if (notifyPropertyChanged)
            {
                SelectedSubCategory = selectedSubCategory;
                return;
            }

            _selectedSubCategory = selectedSubCategory;
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
