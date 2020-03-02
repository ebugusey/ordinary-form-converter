using OFP.ObjectModel.Common;
using OFP.ObjectModel.Localization;

namespace OFP.ObjectModel.FormElements.Data
{
    /// <summary>
    /// Переключатель.
    /// </summary>
    public class RadioButton : Element
    {
        /// <summary>
        /// Заголовок.
        /// </summary>
        public LocalizedString Title { get; set; }

        /// <summary>
        /// ВыбираемоеЗначение.
        /// </summary>
        public SimpleTypeValue SelectionValue { get; set; }

        /// <summary>
        /// ПоложениеЗаголовка.
        /// </summary>
        public TitleLocation TitlePosition { get; set; }

        /// <summary>
        /// Оформление переключателя.
        /// </summary>
        public RadioButtonDecoration Decoration { get; set; }

        /// <summary>
        /// События переключателя.
        /// </summary>
        public Events<RadioButtonEvent> Events { get; set; }

        public RadioButton()
        {
            Title = new LocalizedString();

            SelectionValue = new SimpleTypeValue();

            TitlePosition = TitleLocation.Right;

            Decoration = new RadioButtonDecoration();
            Events = new Events<RadioButtonEvent>();
        }
    }
}
