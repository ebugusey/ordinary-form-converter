namespace OFP.ObjectModel.FormElements.Documents
{

    /// <summary>
    /// События ПолеТабличногоДокумента.
    /// </summary>
    public enum SpreadsheetDocumentFieldEvent
    {
        /// <summary>
        /// Выбор.
        /// </summary>
        OnSelection = 0,

        /// <summary>
        /// ОбработкаРасшифровки.
        /// </summary>
        OnDetailProcessing = 1,

        /// <summary>
        /// ПриАктивизацииОбласти.
        /// </summary>
        OnActivateArea = 2,

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

        /// <summary>
        /// ПриИзмененииСодержимогоОбласти.
        /// </summary>
        OnChangeAreaContent = 7,
    }
}
