namespace OFP.ObjectModel.Common
{
    public class Event<T> where T : Enum
    {
        public string HandlerName { get; set; }
        public T Type { get; set; }
    }
}
