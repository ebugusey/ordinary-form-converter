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
        OnDrag = 3,

        /// <summary>
        /// ПроверкаПеретаскивания.
        /// </summary>
        OnDragAndDropCheck = 4,

        /// <summary>
        /// ОкончаниеПеретаскивания.
        /// </summary>
        OnDropInDataSourse = 5,

        /// <summary>
        /// Перетаскивание.
        /// </summary>
        OnDropInDataReceiver = 6,
    }
}
