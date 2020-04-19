using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Prism.Mvvm;
using Prism.Test.Helpers;
using Prism.Test.Models.Abstract;
using Prism.Test.Models.Items;

namespace Prism.Test.Models
{
    public class YourOrderModel : BindableBase, IYourOrderModel
    {
        public YourOrderModel()
        {
            
        }
        
        public event EventHandler ItemsCountChanged;

        public IList<OrderedItemModel> OrderedItems { get; } = new List<OrderedItemModel>();

        public void AddOrderedItem(MenuOptionItemModel menuOptionItem)
        {
            OrderedItems.Add(new OrderedItemModel(menuOptionItem));
            ItemsCountChanged?.Invoke(this, EventArgs.Empty);
        }
        
        public void RemoveOrderedItem(MenuOptionItemModel menuOptionItem)
        {
            var orderedItem = OrderedItems.FirstOrDefault(i => i.MenuOption.Equals(menuOptionItem));
            if (orderedItem != null)
            {
                OrderedItems.Remove(orderedItem);
                ItemsCountChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}