using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.FormElements
{
    /// <summary>
    /// Выравнивающая линия.
    /// </summary>
    public class AlignmentLine
    {
        /// <summary>
        /// Сквозная.
        /// </summary>
        public bool IsPassThrough { get; set; }

        /// <summary>
        /// Тип.
        /// </summary>
        public AlignmentLineType Type { get; set; }

        /// <summary>
        /// Координата.
        /// </summary>
        public ushort Position { get; set; }

        /// <summary>
        /// Ориентация.
        /// </summary>
        public AlignmentLineOrientation Orientation { get; set; }
    }
}
