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
        Selection = 0,

        /// <summary>
        /// ОбработкаРасшифровки.
        /// </summary>
        DecryptionProcessing = 1,

        /// <summary>
        /// ПриАктивизацииОбласти.
        /// </summary>
        OnActivateArea = 2,

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
        OnEndDragAndDrop = 5,

        /// <summary>
        /// Перетаскивание.
        /// </summary>
        OnDragAndDrop = 6,

        /// <summary>
        /// ПриИзмененииСодержимогоОбласти.
        /// </summary>
        OnChangeAreaContent = 7,
    }
}
