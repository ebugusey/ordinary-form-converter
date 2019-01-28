using System;
using System.Collections.Generic;
using System.Text;
using OFP.ObjectModel.Common;

namespace OFP.ObjectModel.FormElements.Panels
{
    public class Panel : Element
    {
        public bool AutoBindings { get; set; }
        public bool AutoTabOrder { get; set; }
        public PanelDecoration Decor { get; set; }
        public Events<PanelEvent> Events { get; }
        public ShowTabs TabsStyle { get; set; }
        public bool ScrollPageModeEnabled { get; set; }
        public List<PanelPage> Pages { get; }
    }
}
