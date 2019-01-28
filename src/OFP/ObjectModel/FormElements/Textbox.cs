using OFP.ObjectModel.Common;

namespace OFP.ObjectModel.FormElements
{
    public class Textbox : Element
    {
        public bool AutoChoiceIncomplete { get; set; }
        public bool AutoMarkIncomplete { get; set; }
        public bool ChoiceIncomplete { get; set; }
        public bool MarkIncomplete { get; set; }
        public bool ChooseType { get; set; }
        public bool MarkNegatives { get; set; }
        public bool IsDefaultControl { get; set; }
        public bool IsMultiLine { get; set; }
        public bool PasswordMode { get; set; }
        public bool ExtendedEdit { get; set; }
        public bool Wrap { get; set; }

        public decimal MinValue { get; set; }
        public decimal MaxValue { get; set; }

        public string Mask { get; set; }

        public HorizontalAlign HorizontalAlign { get; set; }
        public VerticalAlign VerticalAlign { get; set; }

        public TextboxDecoration Decor { get; set; }

        public Events<TextboxEvent>[] Events { get; set; }
    }

    public enum TextboxEvent
    {
        StartListChoice = 1,
        StartChoice = 2,
        Clearing = 3,
        Tuning = 4,
        Opening = 5,
        ChoiceProcessing = 7,
        TextEditEnd = 10,
        AutoCompleteText = 11,
        OnChange = 2147483647
    }
}
