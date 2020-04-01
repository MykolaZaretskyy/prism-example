using System;
using System.Collections.Generic;
using System.Text;
using Prism.Events;
using Prism.Test.Managers.Abstract;
using Prism.Test.Models.Events;
using Prism.Test.ViewModels;
using Prism.Test.ViewModels.Abstract.Items;

namespace Prism.Test.Managers
{
    class LeftViewModelPropertyChangedHandler : ILeftViewModelPropertyChangedHandler
    {
        private LeftViewModel _viewModel;

        public LeftViewModelPropertyChangedHandler(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<LeftViewModelChangedEvent>().Subscribe(HandleLeftViewModelEvents);
        }

        public void Initialize(LeftViewModel source)
        {
            _viewModel = source;
        }

        private void HandleLeftViewModelEvents(EventPayload eventPayload)
        {
            var eventName = eventPayload.EventName;
            switch (eventName)
            {
                case EventConstants.OnCategorySelected:
                    OnCategorySelected(eventPayload.Data as CategoryItemViewModel);
                    break;
                default:
                    break;
            }
        }

        private void OnCategorySelected(CategoryItemViewModel item)
        {
            item.IsSelected = !item.IsSelected;
        }
    }
}
