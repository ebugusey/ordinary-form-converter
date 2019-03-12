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
        public RadioButtonDecoration Decoration { get; set; }

        /// <summary>
        /// АктивизироватьПоУмолчанию.
        /// </summary>
        public bool ActivetedByDefault { get; set; }

        /// <summary>
        /// События переключателя.
        /// </summary>
        public Events<RadioButtonEvent> Events { get; set; }

        /// <summary>
        /// ГоризонтальноеПоложение.
        /// </summary>
        public HorizontalAlign HorizontalAlign { get; set; }

        /// <summary>
        /// ВыбираемоеЗначение.
        /// </summary>
        public SimpleTypeValue SelectionValue { get; set; }

        /// <summary>
        /// ПоложениеЗаголовка.
        /// </summary>
        public TitleLocation TitlePosition { get; set; }

        /// <summary>
        /// ВертикальноеПоложение.
        /// </summary>
        public VerticalAlign VerticalAlign { get; set; }
    }
}
