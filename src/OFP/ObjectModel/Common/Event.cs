namespace OFP.ObjectModel.Common
{
    public class Event<T>
    {
        public string HandlerName { get; set; }
        public T Type { get; set; }
    }
}
