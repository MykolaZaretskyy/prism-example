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
                new CategoryItemModel("Category 1"),
                new CategoryItemModel("Category 2"),
                new CategoryItemModel("Category 3"),
            };

            GenerateData(Categories.ToList(), 2);
        }

        private void GenerateData(List<CategoryItemModel> list, int level)
        {
            if (level < 0)
            {
                return;
            }
            
            for (var i = 0; i < list.Count; i++)
            {
                var c = list[i];
                c.PopulateWithData(i+1, level, level > 0);
                GenerateData(c.SubCategories.ToList(), level - 1);
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
