using System;
using System.Collections.Generic;
using System.Text;
using OFP.ObjectModel.Common;
using OFP.ObjectModel.Localization;
using OFP.ObjectModel.Platform.Pictures;

namespace OFP.ObjectModel.FormElements.Panels
{
    public class PanelPage
    {
        public Identifier Name { get; set; }
        public LocalizedString Title { get; set; }
        public LocalizedString ToolTip { get; set; }
        public Picture TitlePicture { get; set; }
        public bool Visible { get; set; }
        public bool Enabled { get; set; }
        public List<Element> ChildItems { get; }
    }
}
