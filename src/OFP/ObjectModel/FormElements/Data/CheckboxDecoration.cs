using OFP.ObjectModel.Platform.Borders;
using OFP.ObjectModel.Platform.Colors;
using OFP.ObjectModel.Platform.Fonts;

namespace OFP.ObjectModel.FormElements.Data
{
    public class CheckboxDecoration
    {
        public Border Border { get; set; }
        public Font TextFont { get; set; }
        public Color BackColor { get; set; }
        public Color BorderColor { get; set; }
        public Color TextColor { get; set; }
        public bool IsTransparent { get; set; }
    }
}
