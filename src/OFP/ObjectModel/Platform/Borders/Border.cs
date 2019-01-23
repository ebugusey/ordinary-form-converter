using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.Platform.Borders
{
    public class Border
    {
        public BorderType Type { get; set; }
        public BorderStyle Style { get; set; }
        public byte Width { get; set; }
    }
}
