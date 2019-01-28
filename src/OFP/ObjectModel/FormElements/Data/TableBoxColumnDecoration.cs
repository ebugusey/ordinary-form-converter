using OFP.ObjectModel.Platform;
using OFP.ObjectModel.Platform.Borders;
using OFP.ObjectModel.Platform.Colors;
using OFP.ObjectModel.Platform.Fonts;
using OFP.ObjectModel.Platform.Pictures;
using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.FormElements.Data
{
    public class TableBoxColumnDecoration
    {
        public Border Border { get; set; }
        public Font Font { get; set; }
        public Color FieldBackColor { get; set; }
        public Color FieldTextColor { get; set; }
        public Color FooterBackColor { get; set; }
        public Font FooterFont { get; set; }
        public Picture FooterPicture { get; set; }
        public Color FooterTextColor { get; set; }
        public Picture HeaderAdditionalPicture { get; set; }
        public Color HeaderBackColor { get; set; }
        public Font HeaderFont { get; set; }
        public Picture HeaderPicture { get; set; }
        public Color HeaderTextColor { get; set; }
        public Picture RowsPictures { get; set; }
        public Font TextFont { get; set; }
        public int Width { get; set; }
    }
}
