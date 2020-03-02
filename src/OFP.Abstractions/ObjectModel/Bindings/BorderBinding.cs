using OFP.ObjectModel.FormElements;

namespace OFP.ObjectModel.Bindings
{
    public class BorderBinding
    {
        public Element? BindTo { get; set; }
        public BindingSite BindToSite { get; set; }
        public Element? KeepProportionsTo { get; set; }
        public BindingSite KeepProportionsToSite { get; set; }
    }
}
