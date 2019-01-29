using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.Platform.Fonts
{
    /// <summary>
    /// ШрифтыСтиля.
    /// </summary>
    public enum StandardFontStyle
    {
        /// <summary>
        /// ШрифтТекста.
        /// </summary>
        TextFont = -20,

        /// <summary>
        /// МелкийШрифтТекста.
        /// </summary>
        SmallTextFont = -30,

        /// <summary>
        /// ОбычныйШрифтТекста.
        /// </summary>
        NormalTextFont = -31,

        /// <summary>
        /// КрупныйШрифтТекста.
        /// </summary>
        LargeTextFont = -32,

        /// <summary>
        /// ОченьКрупныйШрифтТекста.
        /// </summary>
        ExtraLargeTextFont = -33,
    }
}
