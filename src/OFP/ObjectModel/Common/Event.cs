namespace OFP.ObjectModel.Common
{
    public class Event<T> where T : Enum
    {
        public string HeandlerName { get; set; }
        public T Type { get; set; }
    }
}
