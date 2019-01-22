using OFP.ObjectModel.Platform;
using OFP.ObjectModel.Common;

namespace OFP.ObjectModel.FormElements
{
    public class ButtonDecoration
    {
        public Border Border { get; set; }
        public Font Font { get; set; }
        public Color BorderColor { get; set; }
        public Color ButtonBackColor { get; set; }
        public Color ButtonTextColor { get; set; }
        public Picture Picture { get; set; }
        public ButtonPictureLocation PictureLocation { get; set; }
        public PictureSize PictureSize { get; set; }
    }

    public enum ButtonPictureLocation
    {
        Left = 0,
        Right = 1
    }
}
