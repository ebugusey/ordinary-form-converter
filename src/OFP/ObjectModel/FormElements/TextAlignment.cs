using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.FormElements
{
    /// <summary>
    /// Выравнивание текста относительно краев элемента.
    /// </summary>
    public class TextAlignment
    {
        /// <summary>
        /// ГоризонтальноеПоложение.
        /// </summary>
        public HorizontalAlign Horizontal { get; set; }

        /// <summary>
        /// ВертикальноеПоложение.
        /// </summary>
        public VerticalAlign Vertical { get; set; }
    }
}
