using OFP.ObjectModel.Common;

namespace OFP.ObjectModel.FormElements
{
    public class Checkbox : Element
    {
        public CheckboxDecoration Decor { get; set; }
        public bool IsDefaultControl { get; set; }
        public HorizontalAlign HorizontalAlign { get; set; }
        public VerticalAlign VerticalAlign { get; set; }
        public TitleLocation TitleLocation { get; set; }
        public Events<CheckboxEvent> Events { get; set; }
    }

    public enum CheckboxEvent
    {
        OnChange = 2147483647
    }
}
