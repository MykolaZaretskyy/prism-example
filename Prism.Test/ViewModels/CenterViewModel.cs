using System.Collections.ObjectModel;
using Prism.Mvvm;
using Prism.Test.ViewModels.Abstract;
using Prism.Test.ViewModels.Abstract.Items;

namespace Prism.Test.ViewModels
{
    public class CenterViewModel : BindableBase, ICenterViewModel
    {
        public CenterViewModel()
        {
            SubCategories = new ObservableCollection<SubCategoryItemViewModel>();
            PopulateSubCategories(1);
        }

        public ObservableCollection<SubCategoryItemViewModel> SubCategories { get; }

        private void PopulateSubCategories(int categoryIndex)
        {
            for (int i = 0; i < 5; i++)
            {
                SubCategories.Add(new SubCategoryItemViewModel { SubCategoryName = $"Subcategory of {categoryIndex} category" });
            }
        }
    }
}
