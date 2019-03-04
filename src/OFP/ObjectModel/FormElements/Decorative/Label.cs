using System;
using System.Collections.Generic;
using System.Text;
using OFP.ObjectModel.Localization;
using OFP.ObjectModel.Common;

namespace OFP.ObjectModel.FormElements.Decorative
{
    /// <summary>
    /// Надпись.
    /// </summary>
    public class Label : Element
    {
        /// <summary>
        /// Заголовок.
        /// </summary>
        public LocalizedString Title { get; set; }

        /// <summary>
        /// Оформление надписи.
        /// </summary>
        public LabelDecoration Decoration { get; set; }

        /// <summary>
        /// События надписи.
        /// </summary>
        public Events<LabelEvent> Events { get; set; }

        /// <summary>
        /// Формат.
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// ГоризонтальноеПоложение.
        /// </summary>
        public HorizontalAlign HorizontalAlign { get; set; }

        /// <summary>
        /// ВертикальноеПоложение.
        /// </summary>
        public VerticalAlign VerticalAlign { get; set; }

        /// <summary>
        /// Гиперссылка.
        /// </summary>
        public bool IsHyperlink { get; set; }

        /// <summary>
        /// ВыделятьОтрицательные.
        /// </summary>
        public bool IsMarkNegativeNumbers { get; set; }

        /// <summary>
        /// БегущаяСтрока.
        /// </summary>
        public ScrollingTextMode ScrollingTextMode { get; set; }
    }
}
