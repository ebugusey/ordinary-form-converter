using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.Forms
{
    public class Window
    {
        public WindowStateVariant windowState { get; set; }
        public bool AllowClose { get; set; }
        public bool DesktopMode { get; set; }
        public WindowSizeChange SizeChange { get; set; }
        public bool ConnectableWindow { get; set; }
        public WindowLocationVariant WindowLocation { get; set; }
        public WindowDockVariant WindowDockLocation { get; set; }
        public WindowAppearanceModeVariant WindowAppearanceMode { get; set; }
        public WindowAppearanceModeChange ChangeWindowAppearanceMode { get; set; }
    }
}
