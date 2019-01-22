using OFP.ObjectModel.Platform.Borders;
using OFP.ObjectModel.Platform.Colors;
using OFP.ObjectModel.Platform.Fonts;

namespace OFP.ObjectModel.FormElements
{
    public class CommandBarDecoration
    {
        public bool IsTransparent { get; set; }
        public Border Border { get; set; }
        public Font Font { get; set; }
        public Color BackColor { get; set; }
        public Color BorderColor { get; set; }
        public Color ButtonBackColor { get; set; }
        public Color ButtonTextColor { get; set; }
    }
}
