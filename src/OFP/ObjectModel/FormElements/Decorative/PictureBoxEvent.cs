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
        OnClick = 0,

        /// <summary>
        /// НачалоПеретаскивания.
        /// </summary>
        OnStartDragAndDrop = 3,

        /// <summary>
        /// ПроверкаПеретаскивания.
        /// </summary>
        OnCheckDragAndDrop = 4,

        /// <summary>
        /// ОкончаниеПеретаскивания.
        /// </summary>
        OnEndDragAndDropInSourceData = 5,

        /// <summary>
        /// Перетаскивание.
        /// </summary>
        OnEndDragAndDropInReceiverData = 6,
    }
}
