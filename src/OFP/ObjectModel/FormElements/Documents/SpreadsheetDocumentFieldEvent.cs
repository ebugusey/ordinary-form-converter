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
        DetailProcessing = 1,

        /// <summary>
        /// ПриАктивизацииОбласти.
        /// </summary>
        OnActivateArea = 2,

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

        /// <summary>
        /// ПриИзмененииСодержимогоОбласти.
        /// </summary>
        OnChangeAreaContent = 7,
    }
}
