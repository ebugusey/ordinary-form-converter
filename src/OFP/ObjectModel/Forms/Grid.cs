using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.Forms
{
    /// <summary>
    /// Сетка.
    /// </summary>
    public class Grid
    {
        /// <summary>
        /// ИспользоватьСетку.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// ГоризонтальныйШагСетки.
        /// </summary>
        public uint HorizontalStep { get; set; }

        /// <summary>
        /// ВертикальныйШагСетки.
        /// </summary>
        public uint VerticalStep { get; set; }
    }
}
