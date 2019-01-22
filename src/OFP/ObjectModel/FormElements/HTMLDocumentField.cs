using OFP.ObjectModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.FormElements
{
    class HTMLDocumentField : Element
    {

        public bool DefaultControl { get; set; }
        public Event<HTMLDocumentField> Events { get; set; }
        public UseOutput Output { get; set; }

    }
}
