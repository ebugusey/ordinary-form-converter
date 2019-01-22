using OFP.ObjectModel.Platform;
using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.FormElements
{
   public class RadioButtonDecoration
    {
        public Border Border { get; set; }
        public Font Font { get; set; }
        public Color BackColor { get; set; }
        public Color BorderColor { get; set; }
        public Color TextColor { get; set; }
        public bool IsTransparent { get; set; }
    }
}
