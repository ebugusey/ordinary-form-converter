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
        public CheckBoxDecoration Decor { get; set; }

        /// <summary>
        /// АктивизироватьПоУмолчанию.
        /// </summary>
        public bool IsDefaultControl { get; set; }

        /// <summary>
        /// ПоложениеЗаголовка.
        /// </summary>
        public TitleLocation TitleLocation { get; set; }

        /// <summary>
        /// События флажка.
        /// </summary>
        public Events<CheckBoxEvent> Events { get; set; }
    }
}
