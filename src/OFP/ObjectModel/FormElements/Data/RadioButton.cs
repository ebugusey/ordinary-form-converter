using OFP.ObjectModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.FormElements.Data
{
    //FIXME: Нет свойства Заголовок.
    /// <summary>
    /// Переключатель.
    /// </summary>
    public class RadioButton : Element
    {
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

        //FIXME: Нет такого свойства в платформе.
        /// <summary>
        /// АктивизироватьПоУмолчанию.
        /// </summary>
        public bool ActivetedByDefault { get; set; }

        /// <summary>
        /// События переключателя.
        /// </summary>
        public Events<RadioButtonEvent> Events { get; set; }
    }
}
