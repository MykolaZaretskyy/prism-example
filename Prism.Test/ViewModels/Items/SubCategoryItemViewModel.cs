using Prism.Mvvm;

namespace Prism.Test.ViewModels.Abstract.Items
{
    public class SubCategoryItemViewModel : BindableBase
    {
        private string _subCategoryName;

        public SubCategoryItemViewModel()
        {
        }

        public string SubCategoryName
        {
            get => _subCategoryName;
            set => SetProperty(ref _subCategoryName, value);
        }
    }
}
