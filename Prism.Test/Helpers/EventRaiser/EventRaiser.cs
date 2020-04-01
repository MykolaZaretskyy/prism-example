using Prism.Events;
using Prism.Test.Models.Events;

namespace Prism.Test.Helpers.EventRaiser
{
    public class EventRaiser : IEventRaiser
    {
        private readonly LeftViewModelChangedEvent _leftViewModelChangedEvent;
        private readonly CenterViewModelChangedEvent _centerViewModelChangedEvent;
        private readonly RightViewModelChangedEvent _rightViewModelChangedEvent;

        public EventRaiser(IEventAggregator eventAggregator)
        {
            _leftViewModelChangedEvent = eventAggregator.GetEvent<LeftViewModelChangedEvent>();
            _centerViewModelChangedEvent = eventAggregator.GetEvent<CenterViewModelChangedEvent>();
            _rightViewModelChangedEvent = eventAggregator.GetEvent<RightViewModelChangedEvent>();
        }

        public void RaiseLeftEvent(EventPayload eventPayload)
        {
            _leftViewModelChangedEvent.Publish(eventPayload);
        }

        public void RaiseCenterEvent(EventPayload eventPayload)
        {
            _centerViewModelChangedEvent.Publish(eventPayload);
        }

        public void RaiseRightEvent(EventPayload eventPayload)
        {
            _rightViewModelChangedEvent.Publish(eventPayload);
        }
    }
}
