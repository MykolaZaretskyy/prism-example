using System;
using System.Collections.Generic;
using System.ComponentModel;
using Prism.Test.Helpers;

namespace Prism.Test.Models.Abstract
{
    public interface ICategoryItemsModel : INotifyPropertyChanged
    {
        event EventHandler<EventArgs<MenuOptionItemModel>> ItemAdded;

        event EventHandler<EventArgs<MenuOptionItemModel>> ItemRemoved;

        IList<MultiStateItemModel> AllCategoryItems { get; }

        void OnFocusedItemChanged(MultiStateItemModel listItem);

        void OnMenuOptionCheckedChanged(MenuOptionItemModel listItem);
    }
}
