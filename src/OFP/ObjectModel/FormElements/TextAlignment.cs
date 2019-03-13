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
        public HorizontalTextAlignment Horizontal { get; set; }

        /// <summary>
        /// ВертикальноеПоложение.
        /// </summary>
        public VerticalTextAlignment Vertical { get; set; }

        public TextAlignment()
        {
            Horizontal = HorizontalTextAlignment.Auto;
            Vertical = VerticalTextAlignment.Top;
        }
    }
}
