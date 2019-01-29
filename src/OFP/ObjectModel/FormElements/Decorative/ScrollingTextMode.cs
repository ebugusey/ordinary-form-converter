using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.FormElements.Decorative
{
    /// <summary>
    /// РежимБегущейСтроки.
    /// </summary>
    public enum ScrollingTextMode
    {
        /// <summary>
        /// НеИспользовать.
        /// </summary>
        DontUse = 0,

        /// <summary>
        /// ОченьМедленно.
        /// </summary>
        VerySlow = 1,

        /// <summary>
        /// Медленно.
        /// </summary>
        Slow = 2,

        /// <summary>
        /// Нормально.
        /// </summary>
        Normal = 3,

        /// <summary>
        /// Быстро.
        /// </summary>
        Fast = 4,

        /// <summary>
        /// ОченьБыстро.
        /// </summary>
        VeryFast = 5,
    }
}
