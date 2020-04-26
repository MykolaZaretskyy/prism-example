using System.Collections.Generic;
using System.ComponentModel;
using Prism.Test.Models.Items;

namespace Prism.Test.Models.Abstract
{
    public interface ICategoriesModel : INotifyPropertyChanged
    {
        IList<CategoryItemModel> Categories { get; }
        
        CategoryItemModel SelectedCategory { get; }

        CategoryItemModel SelectedSubCategory { get; }
        
        IList<object> CategoryItems { get; }

        void SetSelectedCategory(CategoryItemModel selectedCategory);

        void SetSelectedSubCategory(CategoryItemModel selectedSubCategory, bool notifyPropertyChanged = true);
    }
}
