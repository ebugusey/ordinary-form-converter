using OFP.ObjectModel.Common;
using OFP.ObjectModel.FormElements;
using OFP.ObjectModel.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.Forms
{
    public class Form
    {
        public List<Attribute> Attributes { get; }
        public bool AutoFillCheck { get; set; }
        public bool AutoTitle { get; set; }
        public LocalizedString Title { get; set; }
        public bool CloseOnChoice { get; set; }
        public bool CloseOnOwnerClose { get; set; }
        public string DataPath { get; set; }
        public FormDecoration Decor { get; set; }
        public EnterKeyBehaviorType EnterKeyBehavior { get; set; }
        public Events<FormEvent> Events { get; set; }
        public bool ModalMode { get; set; }

        public bool RestoreValuesOnOpen { get; set; }
        public bool SaveValues { get; set; }
        public Size Size { get; set; }

    }
}
