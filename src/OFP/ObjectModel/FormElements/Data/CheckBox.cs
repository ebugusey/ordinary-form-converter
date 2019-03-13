using OFP.ObjectModel.Common;

namespace OFP.ObjectModel.FormElements.Data
{
    /// <summary>
    /// Флажок.
    /// </summary>
    public class CheckBox : Element
    {
        /// <summary>
        /// ПоложениеЗаголовка.
        /// </summary>
        public TitleLocation TitlePosition { get; set; }

        /// <summary>
        /// Оформление флажка.
        /// </summary>
        public CheckBoxDecoration Decoration { get; set; }

        /// <summary>
        /// АктивизироватьПоУмолчанию.
        /// </summary>
        public bool ActivetedByDefault { get; set; }

        /// <summary>
        /// События флажка.
        /// </summary>
        public Events<CheckBoxEvent> Events { get; set; }

        public CheckBox()
        {
            TitlePosition = TitleLocation.Right;

            Decoration = new CheckBoxDecoration();
            Events = new Events<CheckBoxEvent>();
        }
    }
}
