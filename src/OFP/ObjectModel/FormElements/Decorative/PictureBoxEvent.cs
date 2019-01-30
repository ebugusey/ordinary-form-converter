using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.FormElements.Decorative
{
    /// <summary>
    /// Событие ПолеКартинки.
    /// </summary>
    public enum PictureBoxEvent
    {
        /// <summary>
        /// Нажатие.
        /// </summary>
        Click = 0,

        /// <summary>
        /// НачалоПеретаскивания.
        /// </summary>
        DragStart = 3,

        /// <summary>
        /// ПроверкаПеретаскивания.
        /// </summary>
        DragCheck = 4,

        /// <summary>
        /// ОкончаниеПеретаскивания.
        /// </summary>
        DragEnd = 5,

        /// <summary>
        /// Перетаскивание.
        /// </summary>
        Drag = 6,
    }
}
