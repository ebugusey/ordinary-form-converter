using System;
using System.Collections.Generic;
using System.Text;
using OFP.ObjectModel.Common;
using OFP.ObjectModel.Platform.Pictures;
using OFP.ObjectModel.Platform.Borders;
using OFP.ObjectModel.Platform.Fonts;
using OFP.ObjectModel.Platform.Colors;

namespace OFP.ObjectModel.FormElements.Decorative
{
    /// <summary>
    /// Оформление ПолеКартинки.
    /// </summary>
    public class PictureBoxDecoration
    {
        /// <summary>
        /// ПрозрачныйФон.
        /// </summary>
        public bool IsTransparentBackground { get; set; }

        /// <summary>
        /// ЦветФона.
        /// </summary>
        public Color BackgroundColor { get; set; }

        /// <summary>
        /// ЦветТекста.
        /// </summary>
        public Color TextColor { get; set; }

        /// <summary>
        /// Рамка.
        /// </summary>
        public Border Border { get; set; }

        /// <summary>
        /// ЦветРамки.
        /// </summary>
        public Color BorderColor { get; set; }

        /// <summary>
        /// ШрифтТекста.
        /// </summary>
        public Font TextFont { get; set; }

        /// <summary>
        /// Картинка.
        /// </summary>
        public Picture Picture { get; set; }

        /// <summary>
        /// РазмерКартинки.
        /// </summary>
        public PictureSize PictureSize { get; set; }

        public PictureBoxDecoration()
        {
            BackgroundColor = new AutoColor();
            TextColor = new AutoColor();

            Border = new Border();
            BorderColor = new AutoColor();

            TextFont = new AutoFont();

            Picture = new EmptyPicture();
            PictureSize = PictureSize.RealSize;
        }
    }
}
