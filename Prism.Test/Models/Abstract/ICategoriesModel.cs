using System.Collections.Generic;
using System.ComponentModel;

namespace Prism.Test.Models.Abstract
{
    public interface ICategoriesModel : INotifyPropertyChanged
    {
        IList<CategoryItemModel> Categories { get; }
        CategoryItemModel SelectedCategory { get; }
        void OnCategorySelected(CategoryItemModel category);
    }
}
