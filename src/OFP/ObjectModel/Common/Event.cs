namespace OFP.ObjectModel.Common
{
    public class Event<T>
    {
        public string HeandlerName { get; set; }
        public T Type { get; set; }
    }
}
