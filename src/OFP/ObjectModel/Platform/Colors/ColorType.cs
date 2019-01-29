using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.Platform.Colors
{
    /// <summary>
    /// ВидЦвета.
    /// </summary>
    public enum ColorType
    {
        /// <summary>
        /// Абсолютный.
        /// </summary>
        Absolute = 0,

        /// <summary>
        /// WindowsЦвет.
        /// </summary>
        WindowsColor = 1,

        /// <summary>
        /// WebЦвет.
        /// </summary>
        WebColor = 2,

        /// <summary>
        /// ЭлементСтиля.
        /// </summary>
        StyleItem = 3,

        /// <summary>
        /// АвтоЦвет.
        /// </summary>
        AutoColor = 4,
    }
}
