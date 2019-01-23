using System.Collections.Generic;
using OFP.ObjectModel.Common;

namespace OFP.ObjectModel.FormElements
{
    public class CommandBar : Element
    {
        public string ActionSource { get; set; }

        public bool DefaultControl { get; set; }
        public bool Secondary { get; set; }
        public bool AutoFill { get; set; }

        public CommandBarDecoration Decor { get; set; }

        public Orientation Orientation { get; set; }
        public CommandBarButtonAlignment ButtonsAlignment { get; set; }

        public List<CommandBarButton> ChildElements { get; set; }
    }
}
