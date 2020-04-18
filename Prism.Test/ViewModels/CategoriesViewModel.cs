using System.Collections.Generic;
using System.Windows.Input;
using Prism.Commands;
using Prism.Test.Models;
using Prism.Test.Models.Abstract;
using Prism.Test.ViewModels.Abstract;

namespace Prism.Test.ViewModels
{
    public class CategoriesViewModel : BaseSectionViewModel
    {
        private readonly ICategoriesModel _categoriesModel;

        public CategoriesViewModel(ICategoriesModel categoriesModel)
        {
            _categoriesModel = categoriesModel;
            Categories = categoriesModel.Categories;

            CategorySelectedCommand = new DelegateCommand<CategoryItemModel>(OnCategorySelected);
        }

        public ICommand CategorySelectedCommand { get; }

        public IList<CategoryItemModel> Categories { get; }

        private void OnCategorySelected(CategoryItemModel item)
        {
            _categoriesModel.OnCategorySelected(item);
        }
    }
}
