using Prism.Mvvm;
using Prism.Test.Helpers;
using Prism.Test.ViewModels.Abstract;
using Prism.Test.ViewModels.Items;

namespace Prism.Test.ViewModels
{
    public class CenterViewModel : BindableBase, ICenterViewModel
    {
        public CenterViewModel() 
        {
            SubCategories = new CustomObservableCollection<SubCategoryItemViewModel>();
        }

        public CustomObservableCollection<SubCategoryItemViewModel> SubCategories { get; }
    }
}
