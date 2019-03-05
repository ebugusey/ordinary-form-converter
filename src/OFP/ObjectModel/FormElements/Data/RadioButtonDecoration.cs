using OFP.ObjectModel.Platform;
using OFP.ObjectModel.Platform.Borders;
using OFP.ObjectModel.Platform.Colors;
using OFP.ObjectModel.Platform.Fonts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.FormElements.Data
{
   public class RadioButtonDecoration
    {
        /// <summary>
        /// Рамка.
        /// </summary>
        public Border Border { get; set; }

        /// <summary>
        /// Шрифт.
        /// </summary>
        public Font Font { get; set; }

        /// <summary>
        /// ЦветФона.
        /// </summary>
        public Color BackColor { get; set; }

        /// <summary>
        /// ЦветРамки.
        /// </summary>
        public Color BorderColor { get; set; }

        /// <summary>
        /// ЦветТекста.
        /// </summary>
        public Color TextColor { get; set; }

        /// <summary>
        /// ПрозрачныйФон.
        /// </summary>
        public bool IsTransparent { get; set; }

        /// <summary>
        /// Выравнивание текста переключателя.
        /// </summary>
        public TextAlignment TextAlignment { get; }
    }
}
