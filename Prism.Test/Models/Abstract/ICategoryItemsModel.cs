using System.ComponentModel;

namespace Prism.Test.Models.Abstract
{
    public interface ICategoryItemsModel : INotifyPropertyChanged
    {
        MultiStateItemModel FocusedItem { get; set; }
    }
}
