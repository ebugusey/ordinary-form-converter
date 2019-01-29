using System;
using System.Collections.Generic;
using System.Text;
using OFP.ObjectModel.Common;

namespace OFP.ObjectModel.FormElements
{
    /// <summary>
    /// Расположение.
    /// </summary>
    public class Position
    {
        /// <summary>
        /// Координаты верхневого левого угла.
        /// </summary>
        public Point TopLeft { get; set; }

        public Point BottomRight { get; set; }

        /// <summary>
        /// ПорядокОбхода.
        /// </summary>
        public uint TabOrder { get; set; }
    }
}
