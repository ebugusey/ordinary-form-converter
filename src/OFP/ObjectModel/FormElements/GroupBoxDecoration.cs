using OFP.ObjectModel.Platform;
using OFP.ObjectModel.Platform.Borders;
using OFP.ObjectModel.Platform.Colors;
using OFP.ObjectModel.Platform.Fonts;

namespace OFP.ObjectModel.FormElements
{
    public class GroupBoxDecoration
    {
        public bool IsTransparent { get; set; }
        public Border Border { get; set; }
        public Font Font { get; set; }
        public Color BorderColor { get; set; }
        public Color TextColor { get; set; }
    }
}
