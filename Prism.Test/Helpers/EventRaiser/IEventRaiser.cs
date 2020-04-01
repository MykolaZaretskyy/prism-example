using Prism.Test.Models.Events;

namespace Prism.Test.Helpers.EventRaiser
{
    public interface IEventRaiser
    {
        void RaiseLeftEvent(EventPayload eventPayload);
        void RaiseCenterEvent(EventPayload eventPayload);
        void RaiseRightEvent(EventPayload eventPayload);
    }
}
