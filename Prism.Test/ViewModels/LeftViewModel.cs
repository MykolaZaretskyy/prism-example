using System.Collections.Generic;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Test.ViewModels.Abstract;
using Prism.Test.ViewModels.Items;

namespace Prism.Test.ViewModels
{
    public class LeftViewModel : BindableBase, ILeftViewModel
    {
        public LeftViewModel()
        {
            Categories = new List<CategoryItemViewModel>
            {
                new CategoryItemViewModel {CategoryName = "CategoryName 1"},
                new CategoryItemViewModel {CategoryName = "CategoryName 2"},
                new CategoryItemViewModel {CategoryName = "CategoryName 3"},
                new CategoryItemViewModel {CategoryName = "CategoryName 4"},
                new CategoryItemViewModel {CategoryName = "CategoryName 5"},
                new CategoryItemViewModel {CategoryName = "CategoryName 6"},
            };

            CategorySelectedCommand = new DelegateCommand<CategoryItemViewModel>(OnCategorySelected);
        }

        public ICommand CategorySelectedCommand { get; }

        public IList<CategoryItemViewModel> Categories { get; }

        public string Placeholder { get; } = "My Placeholder";

        private void OnCategorySelected(CategoryItemViewModel item)
        {
        }
    }
}
