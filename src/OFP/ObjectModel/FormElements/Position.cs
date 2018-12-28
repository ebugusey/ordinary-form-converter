using System;
using System.Collections.Generic;
using System.Text;
using OFP.ObjectModel.Common;

namespace OFP.ObjectModel.FormElements
{
    public class Position
    {
        public Point TopLeft { get; set; }
        public Point BottomRight { get; set; }
        public uint TabOrder { get; set; }
    }
}
