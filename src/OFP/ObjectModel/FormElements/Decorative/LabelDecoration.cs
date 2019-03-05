using System;
using System.Collections.Generic;
using System.Text;
using OFP.ObjectModel.Common;
using OFP.ObjectModel.Platform.Borders;
using OFP.ObjectModel.Platform.Colors;
using OFP.ObjectModel.Platform.Fonts;
using OFP.ObjectModel.Platform.Pictures;

namespace OFP.ObjectModel.FormElements.Decorative
{
    /// <summary>
    /// Оформление надписи.
    /// </summary>
    public class LabelDecoration
    {
        /// <summary>
        /// Рамка.
        /// </summary>
        public Border Border { get; set; }

        /// <summary>
        /// ШрифтТекста.
        /// </summary>
        public Font TextFont { get; set; }

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
        /// Картинка.
        /// </summary>
        public Picture Picture { get; set; }

        /// <summary>
        /// ПоложениеКартинкиНадписи.
        /// </summary>
        public LabelPicturePosition PicturePosition { get; set; }

        /// <summary>
        /// РазмерКартинки.
        /// </summary>
        public PictureSize PictureSize { get; set; }

        /// <summary>
        /// ПрозрачныйФон.
        /// </summary>
        public bool IsTransparent { get; set; }

        /// <summary>
        /// Выравнивание текста надписи.
        /// </summary>
        public TextAlignment TextAlignment { get; }
    }
}
