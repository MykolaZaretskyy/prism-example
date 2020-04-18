using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using Prism.Test.Extensions;
using Prism.Test.Helpers;
using Prism.Test.Models;
using Prism.Test.Models.Abstract;
using Prism.Test.Models.Items;
using Prism.Test.ViewModels.Abstract;

namespace Prism.Test.ViewModels
{
    public class YourOrderViewModel : BaseSectionViewModel
    {
        private readonly List<IDisposable> _disposables;
        private readonly ICategoryItemsModel _categoryItemsModel;

        public YourOrderViewModel(ICategoryItemsModel categoryItemsModel)
        {
            _categoryItemsModel = categoryItemsModel;
            _disposables = new List<IDisposable>();
            SubscribeToEvents();
        }

        public CustomObservableCollection<OrderedItemModel> OrderedItems { get; } = new CustomObservableCollection<OrderedItemModel>();

        private void SubscribeToEvents()
        {
            Observable.FromEventPattern<EventHandler<EventArgs<MenuOptionItemModel>>, EventArgs<MenuOptionItemModel>>(
                    h => _categoryItemsModel.ItemAdded += h,
                    h => _categoryItemsModel.ItemAdded -= h)
                .Select(x => x.EventArgs.Data)
                .Subscribe(AddItem)
                .DisposeWith(_disposables);

            Observable.FromEventPattern<EventHandler<EventArgs<MenuOptionItemModel>>, EventArgs<MenuOptionItemModel>>(
                    h => _categoryItemsModel.ItemRemoved += h,
                    h => _categoryItemsModel.ItemRemoved -= h)
                .Select(x => x.EventArgs.Data)
                .Subscribe(RemoveItem)
                .DisposeWith(_disposables);
        }

        public void AddItem(MenuOptionItemModel item)
        {
            OrderedItems.Add(new OrderedItemModel(item));
        }

        public void RemoveItem(MenuOptionItemModel item)
        {
            var itemToRemove = OrderedItems.FirstOrDefault(e => e.MenuOption == item);
            if (itemToRemove != null)
            {
                OrderedItems.Remove(itemToRemove);
            }
        }
    }
}
