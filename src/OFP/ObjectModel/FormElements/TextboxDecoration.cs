using OFP.ObjectModel.Platform;
using OFP.ObjectModel.Platform.Borders;
using OFP.ObjectModel.Platform.Fonts;
using OFP.ObjectModel.Platform.Pictures;
using OFP.ObjectModel.Platform.Colors;

namespace OFP.ObjectModel.FormElements
{
    public class TextboxDecoration
    {
        public bool IsTransparent { get; set; }
        public ushort ChoiceListHeight { get; set; }
        public ushort ChoiceListWidth { get; set; }
        public Border Border { get; set; }
        public Font Font { get; set; }
        public Color BorderColor { get; set; }
        public Color ButtonBackColor { get; set; }
        public Color ButtonTextColor { get; set; }
        public Color FieldBackColor { get; set; }
        public Color FieldTextColor { get; set; }
        public Picture Picture { get; set; }
        public Picture ChoiceButtonPicture { get; set; }
    }
}
