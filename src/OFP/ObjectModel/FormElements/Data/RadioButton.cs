using OFP.ObjectModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.FormElements.Data
{
    /// <summary>
    /// Переключатель.
    /// </summary>
    public class RadioButton : Element
    {
        /// <summary>
        /// Оформление переключателя.
        /// </summary>
        public RadioButtonDecoration Decor { get; set; }

        /// <summary>
        /// АктивизироватьПоУмолчанию.
        /// </summary>
        public bool IsDefaultControl { get; set; }

        /// <summary>
        /// События переключателя.
        /// </summary>
        public Events<RadioButtonEvent> Events { get; set; }

        /// <summary>
        /// ВыбираемоеЗначение.
        /// </summary>
        public SimpleTypeValue SelectionValue { get; set; }

        /// <summary>
        /// ПоложениеЗаголовка.
        /// </summary>
        public TitleLocation TitleLocation { get; set; }
    }
}
