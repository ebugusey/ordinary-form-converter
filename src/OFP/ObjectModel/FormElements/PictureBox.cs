using System;
using System.Collections.Generic;
using System.Text;
using OFP.ObjectModel.Common;
using OFP.ObjectModel.Platform;
using OFP.ObjectModel.Localization;

namespace OFP.ObjectModel.FormElements
{
    public class PictureBox : Element
    {
        public PictureBoxDecoration Decor { get; set; }
        public bool DragEnabled { get; set; }
        public bool StartDragEnabled { get; set; }
        public bool IsHyperlink { get; set; }
        public LocalizedString NonselectedPictureText { get; set; }
        public bool ContextMenuEnabled { get; set; }
        public bool Zoomable { get; set; }
        public Shortcut Shortcut { get; set; }
        public Events<PictureBoxEvent> Events { get; set; }
    }
}
