using System.Collections.Generic;
using System.ComponentModel;
using Prism.Test.Models.Items;

namespace Prism.Test.Models.Abstract
{
    public interface ICategoriesModel : INotifyPropertyChanged
    {
        IList<CategoryItemModel> Categories { get; }
        CategoryItemModel SelectedCategory { get; set; }
    }
}
