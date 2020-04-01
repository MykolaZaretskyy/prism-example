using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Events;
using Prism.Test.Helpers.EventRaiser;
using Prism.Test.Managers.Abstract;
using Prism.Test.Models.Events;
using Prism.Test.ViewModels;
using Prism.Test.ViewModels.Abstract.Items;

namespace Prism.Test.Managers
{
    class CenterViewModelPropertyChangedHandler : ICenterViewModelPropertyChangedHandler
    {
        private CenterViewModel _viewModel;
        private readonly IEventRaiser _eventRaiser;

        public CenterViewModelPropertyChangedHandler(IEventAggregator eventAggregator, IEventRaiser eventRaiser)
        {
            _eventRaiser = eventRaiser;
            eventAggregator.GetEvent<LeftViewModelChangedEvent>().Subscribe(HandleLeftViewModelEvents);
            eventAggregator.GetEvent<CenterViewModelChangedEvent>().Subscribe(HandleCenterViewModelEvents);
        }

        public void Initialize(CenterViewModel source)
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
                    _eventRaiser.RaiseCenterEvent(EventPayload.Create(EventConstants.OnSubcategoriesSet,
                        _viewModel.SubCategories[0].SubCategoryName));
                    break;
                default:
                    break;
            }
        }

        private void HandleCenterViewModelEvents(EventPayload obj)
        {
        }

        private void OnCategorySelected(CategoryItemViewModel eventPayloadData)
        {
            var categoryIndex = int.Parse(eventPayloadData.CategoryName.Last().ToString());
            PopulateSubCategories(categoryIndex);
        }

        private void PopulateSubCategories(int categoryIndex)
        {
            var subCategories = new List<SubCategoryItemViewModel>();
            for (var i = 0; i < 5; i++)
            {
                subCategories.Add(new SubCategoryItemViewModel { SubCategoryName = $"Subcategory of {categoryIndex} category" });
            }

            _viewModel.SubCategories.ReplaceWith(subCategories);
        }
    }
}
