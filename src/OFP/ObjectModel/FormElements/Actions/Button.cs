using System.Collections.Generic;
using OFP.ObjectModel.Common;
using OFP.ObjectModel.Localization;
using OFP.ObjectModel.Platform;

namespace OFP.ObjectModel.FormElements.Actions
{
    class Button : Element
    {
        public string ActionSource { get; set; }
        public LocalizedString Title { get; set; }

        public bool DefaultButton { get; set; }
        public bool DefaultControl { get; set; }
        public bool MultiLine { get; set; }

        public HorizontalAlign HorizontalAlign { get; set; }
        public VerticalAlign VerticalAlign { get; set; }
        public UseMenuMode MenuMode { get; set; }

        public ButtonDecoration Decor { get; set; }
        public Shortcut Shortcut { get; set; }

        public List<CommandBarButton> ChildElements { get; set; }

        public Events<ButtonEvent> Events { get; set; }
    }
}
