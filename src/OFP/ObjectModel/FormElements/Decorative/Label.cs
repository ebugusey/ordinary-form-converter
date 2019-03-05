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
        public LabelDecoration Decor { get; set; }

        /// <summary>
        /// События надписи.
        /// </summary>
        public Events<LabelEvent> Events { get; set; }

        /// <summary>
        /// Формат.
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Гиперссылка.
        /// </summary>
        public bool IsHyperlink { get; set; }

        /// <summary>
        /// ВыделятьОтрицательные.
        /// </summary>
        public bool MarkNegatives { get; set; }

        /// <summary>
        /// БегущаяСтрока.
        /// </summary>
        public ScrollingTextMode ScrollingText { get; set; }
    }
}
