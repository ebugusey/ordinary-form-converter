using OFP.ObjectModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.FormElements
{
    public class HTMLDocumentField : Element
    {
        public HTMLDocumentFieldDecoration Decor { get; set; }
        public bool DefaultControl { get; set; }
        public Event<HTMLDocumentFieldEvent> Events { get; set; }
        public UseOutput Output { get; set; }
    }
}
