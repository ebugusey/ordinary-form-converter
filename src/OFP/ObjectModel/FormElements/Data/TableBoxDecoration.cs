using OFP.ObjectModel.Platform;
using OFP.ObjectModel.Platform.Borders;
using OFP.ObjectModel.Platform.Colors;
using OFP.ObjectModel.Platform.Fonts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.FormElements.Data
{
    /// <summary>
    /// Оформление табличного поля.
    /// </summary>
    public class TableBoxDecoration
    {
        /// <summary>
        /// Рамка.
        /// </summary>
        public Border Border { get; set; }

        /// <summary>
        /// Шрифт.
        /// </summary>
        public Font TextFont { get; set; }

        /// <summary>
        /// ЦветФонаЧередованияСтрок.
        /// </summary>
        public Color InterlacingColor { get; set; }

        /// <summary>
        /// ЦветРамки.
        /// </summary>
        public Color BorderColor { get; set; }

        /// <summary>
        /// ЦветФонаПоля.
        /// </summary>
        public Color FieldBackgroundColor { get; set; }

        /// <summary>
        /// ЦветТекстаПоля.
        /// </summary>
        public Color FieldTextColor { get; set; }

        /// <summary>
        /// ЦветТекстаПодвала.
        /// </summary>
        public Color FooterBackgroundColor { get; set; }

        /// <summary>
        /// ШрифтПодвала.
        /// </summary>
        public Font FooterTextFont { get; set; }

        /// <summary>
        /// ЦветТекстаПодвала.
        /// </summary>
        public Color FooterTextColor { get; set; }

        /// <summary>
        /// ЦветФонаШапки.
        /// </summary>
        public Color HeaderBackgroundColor { get; set; }

        /// <summary>
        /// ШрифтШапки.
        /// </summary>
        public Font HeaderTextFont { get; set; }

        /// <summary>
        /// ЦветТекстаШапки.
        /// </summary>
        public Color HeaderTextColor { get; set; }

        /// <summary>
        /// ГоризонтальныеЛинии.
        /// </summary>
        public bool HorizontalLinesVisible { get; set; }

        /// <summary>
        /// ЦветФонаВыделения.
        /// </summary>
        public Color SelectionBackgroundColor { get; set; }

        /// <summary>
        /// ЦветТекстаВыделения.
        /// </summary>
        public Color SelectionTextColor { get; set; }

        /// <summary>
        /// ЧередованиеЦветовСтрок.
        /// </summary>
        public bool InterlacingEnabled { get; set; }

        /// <summary>
        /// ВертикальныеЛинии.
        /// </summary>
        public bool VerticalLinesVisible { get; set; }
    }
}
