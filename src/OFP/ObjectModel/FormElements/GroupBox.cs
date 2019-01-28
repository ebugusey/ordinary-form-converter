using OFP.ObjectModel.Localization;

namespace OFP.ObjectModel.FormElements
{
    public class GroupBox : Element
    {
        public LocalizedString Title { get; set; }
        public GroupBoxDecoration Decor { get; set; }
    }
}
