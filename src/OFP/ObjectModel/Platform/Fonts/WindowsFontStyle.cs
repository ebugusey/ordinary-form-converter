using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.Platform.Fonts
{
    /// <summary>
    /// WindowsШрифты.
    /// </summary>
    public enum WindowsFontStyle
    {
        /// <summary>
        /// ШрифтДиалоговИМеню.
        /// </summary>
        DefaultGUIFont = 0,

        /// <summary>
        /// OEMШрифтМоноширинный.
        /// </summary>
        OEMFixedFont = 1,

        /// <summary>
        /// ANSIШрифтМоноширинный.
        /// </summary>
        ANSIFixedFont = 2,

        /// <summary>
        /// ANSIШрифтПропорциональный.
        /// </summary>
        ANSIVariableFont = 3,

        /// <summary>
        /// СистемныйШрифт.
        /// </summary>
        SystemFont = 4,
    }
}
