using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Mvvm;
using Prism.Test.Extensions;
using Prism.Test.Helpers;
using Prism.Test.Models.Abstract;

namespace Prism.Test.Models
{
    public class CategoryItemsModel : BindableBase, ICategoryItemsModel
    {
        private MultiStateItemModel _focusedItem;

        public CategoryItemsModel()
        {
            
        }

        public event EventHandler<EventArgs<MenuOptionItemModel>> ItemAdded;

        public event EventHandler<EventArgs<MenuOptionItemModel>> ItemRemoved;

        public IList<MultiStateItemModel> AllCategoryItems { get; } = new List<MultiStateItemModel>();
        public IList<MenuOptionItemModel> SelectedItems { get; } = new List<MenuOptionItemModel>();

        public IEnumerable<CategoryItemModel> SubCategories => AllCategoryItems.OfType<CategoryItemModel>();

        public IEnumerable<MenuOptionItemModel> MenuOptions => AllCategoryItems.OfType<MenuOptionItemModel>();

        public MultiStateItemModel FocusedItem
        {
            get => _focusedItem;
            private set => SetProperty(ref _focusedItem, value);
        }

        public void OnSubCategorySelected(CategoryItemModel subCategory)
        {
            AllCategoryItems.ReplaceWith(subCategory.AllItems);
        }

        public void OnFocusedItemChanged(MultiStateItemModel listItem)
        {
            if (FocusedItem != null)
            {
                FocusedItem.State = ListItemState.None;
            }

            listItem.State = ListItemState.Focused;
            FocusedItem = listItem;
        }

        public void OnMenuOptionCheckedChanged(MenuOptionItemModel listItem)
        {
            if (listItem.State.HasFlag(ListItemState.Selected))
            {
                listItem.State &= ~ListItemState.Selected;
                listItem.State |= ListItemState.None;
                ItemRemoved?.Invoke(this, new EventArgs<MenuOptionItemModel>(listItem));
            }
            else
            {
                listItem.State &= ~ListItemState.None;
                listItem.State |= ListItemState.Selected;
                ItemAdded?.Invoke(this, new EventArgs<MenuOptionItemModel>(listItem));
            }
        }
    }
}
