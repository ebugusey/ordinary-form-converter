using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.Platform.Pictures
{
    /// <summary>
    /// ВидКартинки.
    /// </summary>
    public enum PictureType
    {
        /// <summary>
        /// Пустая.
        /// </summary>
        Empty = 0,

        /// <summary>
        /// ИзБиблиотеки.
        /// </summary>
        FromLib = 1,

        /// <summary>
        /// Абсолютная.
        /// </summary>
        Absolute = 3,
    }
}
