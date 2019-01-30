using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.FormElements.Panels
{
    /// <summary>
    /// ОтображениеЗакладок.
    /// </summary>
    public enum ShowTabs
    {
        /// <summary>
        /// НеИспользовать.
        /// </summary>
        DontUse = 0,

        /// <summary>
        /// Сверху.
        /// </summary>
        Top = 1,

        /// <summary>
        /// Снизу.
        /// </summary>
        Bottom = 2,

        /// <summary>
        /// СлеваВертикально.
        /// </summary>
        LeftVertical = 3,

        /// <summary>
        /// СправаВертикально.
        /// </summary>
        RightVertical = 4,

        /// <summary>
        /// СлеваГоризонтально.
        /// </summary>
        LeftHorizontal = 5,

        /// <summary>
        /// СправаГоризонтально.
        /// </summary>
        RightHorizontal = 6,

        /// <summary>
        /// СверхуСПрокруткой.
        /// </summary>
        TopScrolling = 7,

        /// <summary>
        /// СверхуМногострочный.
        /// </summary>
        TopMultiLine = 8,

        /// <summary>
        /// СверхуМногострочныйСПерестановкой.
        /// </summary>
        TopMultilineTransposition = 9,

        /// <summary>
        /// СнизуСПрокруткой.
        /// </summary>
        BottomScrolling = 10,

        /// <summary>
        /// СнизуМногострочный.
        /// </summary>
        BottomMultiLine = 11,

        /// <summary>
        /// СнизуМногострочныйСПерестановкой.
        /// </summary>
        BottomMultilineTransposition = 12,
    }
}
