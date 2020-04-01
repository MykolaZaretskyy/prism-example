namespace Prism.Test.Models.Events
{
    public class EventPayload
    {
        public string EventName { get; set; }
        public object Data { get; set; }

        public static EventPayload Create(string eventName, object data)
        {
            return new EventPayload {Data = data, EventName = eventName};
        }
    }
}
