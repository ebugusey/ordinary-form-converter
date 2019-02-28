using OFP.ObjectModel.Common;

namespace OFP.ObjectModel.FormElements.Data
{
    /// <summary>
    /// Флажок.
    /// </summary>
    public class CheckBox : Element
    {
        /// <summary>
        /// Оформление флажка.
        /// </summary>
        public CheckBoxDecoration Decoration { get; set; }

        /// <summary>
        /// АктивизироватьПоУмолчанию.
        /// </summary>
        public bool IsActivateByDefault { get; set; }

        /// <summary>
        /// ГоризонтальноеПоложение.
        /// </summary>
        public HorizontalAlign HorizontalAlign { get; set; }

        /// <summary>
        /// ВертикальноеПоложение.
        /// </summary>
        public VerticalAlign VerticalAlign { get; set; }

        /// <summary>
        /// ПоложениеЗаголовка.
        /// </summary>
        public TitleLocation TitlePosition { get; set; }

        /// <summary>
        /// События флажка.
        /// </summary>
        public Events<CheckBoxEvent> Events { get; set; }
    }
}
