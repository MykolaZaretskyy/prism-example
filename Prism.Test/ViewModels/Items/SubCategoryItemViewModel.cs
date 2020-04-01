using Prism.Mvvm;

namespace Prism.Test.ViewModels.Items
{
    public class SubCategoryItemViewModel : BindableBase
    {
        private string _subCategoryName;

        public string SubCategoryName
        {
            get => _subCategoryName;
            set => SetProperty(ref _subCategoryName, value);
        }
    }
}
