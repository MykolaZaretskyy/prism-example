using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using Prism.Test.Extensions;
using Prism.Test.Helpers;
using Prism.Test.Models.Abstract;
using Prism.Test.Models.Items;
using Prism.Test.ViewModels.Abstract;

namespace Prism.Test.ViewModels
{
    public class YourOrderViewModel : BaseSectionViewModel
    {
        private readonly IYourOrderModel _yourOrderModel;
        private readonly List<IDisposable> _disposables;

        public YourOrderViewModel(IYourOrderModel yourOrderModel)
        {
            _yourOrderModel = yourOrderModel;
            _disposables = new List<IDisposable>();
            SubscribeToEvents();
        }

        public CustomObservableCollection<OrderedItemModel> OrderedItems { get; } = new CustomObservableCollection<OrderedItemModel>();

        private void SubscribeToEvents()
        {
            Observable.FromEventPattern<EventHandler, EventArgs>(
                    h => _yourOrderModel.ItemsCountChanged += h,
                    h => _yourOrderModel.ItemsCountChanged -= h)
                .Subscribe(_ => ItemsCountChanged())
                .DisposeWith(_disposables);
        }

        private void ItemsCountChanged()
        {
            OrderedItems.ReplaceWith(_yourOrderModel.OrderedItems);
        }
    }
}
