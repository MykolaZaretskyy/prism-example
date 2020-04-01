using Prism.Events;
using Prism.Test.Managers.Abstract;
using Prism.Test.Models.Events;
using Prism.Test.ViewModels;

namespace Prism.Test.Managers
{
    public class RightViewModelPropertyChangedHandler : IRightViewModelPropertyChangedHandler
    {
        private RightViewModel _viewModel;

        public RightViewModelPropertyChangedHandler(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<CenterViewModelChangedEvent>().Subscribe(HandleCenterViewModelEvents);
        }

        public void Initialize(RightViewModel source)
        {
            _viewModel = source;
        }

        private void HandleCenterViewModelEvents(EventPayload eventPayload)
        {
            var eventName = eventPayload.EventName;
            switch (eventName)
            {
                case EventConstants.OnSubcategoriesSet:
                    _viewModel.RightText = (string) eventPayload.Data;
                    break;
                default:
                    break;
            }
        }
    }
}
