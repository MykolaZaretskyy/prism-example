using Prism.Mvvm;
using Prism.Test.Helpers;
using Prism.Test.ViewModels.Abstract;
using Prism.Test.ViewModels.Abstract.Items;

namespace Prism.Test.ViewModels
{
    public class CenterViewModel : BindableBase, ICenterViewModel
    {
        public CenterViewModel()
        {
            SubCategories = new CusTomObservableCollection<SubCategoryItemViewModel>();
        }

        public CusTomObservableCollection<SubCategoryItemViewModel> SubCategories { get; }
    }
}
