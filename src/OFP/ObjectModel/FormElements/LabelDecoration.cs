using System;
using System.Collections.Generic;
using System.Text;
using OFP.ObjectModel.Common;
using OFP.ObjectModel.Platform.Borders;
using OFP.ObjectModel.Platform.Colors;
using OFP.ObjectModel.Platform.Fonts;
using OFP.ObjectModel.Platform.Pictures;

namespace OFP.ObjectModel.FormElements
{
    public class LabelDecoration
    {
        public Border Border { get; set; }
        public Font TextFont { get; set; }
        public Color BackColor { get; set; }
        public Color BorderColor { get; set; }
        public Color TextColor { get; set; }
        public Picture Picture { get; set; }
        public PicturePosition PicturePosition { get; set; }
        public PictureSize PictureSize { get; set; }
        public bool IsTransparent { get; set; }
    }
}
