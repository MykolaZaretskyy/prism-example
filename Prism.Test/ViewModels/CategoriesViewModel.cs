using System.Collections.Generic;
using System.Windows.Input;
using Prism.Commands;
using Prism.Test.Managers.Abstract;
using Prism.Test.Models.Abstract;
using Prism.Test.Models.Items;
using Prism.Test.ViewModels.Abstract;

namespace Prism.Test.ViewModels
{
    public class CategoriesViewModel : BaseSectionViewModel
    {
        private readonly ICategoriesModel _categoriesModel;
        private readonly ICategoriesManager _categoriesManager;

        public CategoriesViewModel(ICategoriesModel categoriesModel, ICategoriesManager categoriesManager)
        {
            _categoriesModel = categoriesModel;
            _categoriesManager = categoriesManager;
            Categories = categoriesModel.Categories;

            CategorySelectedCommand = new DelegateCommand<CategoryItemModel>(OnCategorySelected);
        }

        public ICommand CategorySelectedCommand { get; }

        public IList<CategoryItemModel> Categories { get; }

        private void OnCategorySelected(CategoryItemModel item)
        {
            _categoriesManager.OnCategorySelected(item);
        }
    }
}
