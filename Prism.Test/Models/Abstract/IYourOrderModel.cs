using System;
using System.Collections.Generic;
using Prism.Test.Models.Items;

namespace Prism.Test.Models.Abstract
{
    public interface IYourOrderModel
    {
        event EventHandler ItemsCountChanged;
        IList<OrderedItemModel> OrderedItems { get; }
        void AddOrderedItem(MenuOptionItemModel menuOptionItem);
        void RemoveOrderedItem(MenuOptionItemModel menuOptionItem);
    }
}