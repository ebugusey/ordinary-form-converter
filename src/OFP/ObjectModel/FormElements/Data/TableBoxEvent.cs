namespace OFP.ObjectModel.FormElements.Data
{
    /// <summary>
    /// События табличного поля.
    /// </summary>
    public enum TableBoxEvent
    {
        /// <summary>
        /// Выбор.
        /// </summary>
        Selection = 34,

        /// <summary>
        /// ПриАктивизацииСтроки.
        /// </summary>
        OnActivateRow = 35,

        /// <summary>
        /// ПриАктивизацииКолонки.
        /// </summary>
        OnActivateColumn = 36,

        /// <summary>
        /// ПриАктивизацииЯчейки.
        /// </summary>
        OnActivateCell = 37,

        /// <summary>
        /// ПередНачаломДобавления.
        /// </summary>
        BeforeAddRow = 40,

        /// <summary>
        /// ПередНачаломИзменения.
        /// </summary>
        BeforeRowChange = 41,

        /// <summary>
        /// ПередНачаломИзменения.
        /// </summary>
        BeforeDeleteRow = 42,

        /// <summary>
        /// ПриНачалеРедактирования.
        /// </summary>
        OnStartEdit = 43,

        /// <summary>
        /// ПередОкончаниемРедактирования.
        /// </summary>
        BeforeEditEnd = 44,

        /// <summary>
        /// ПриИзмененииФлажка.
        /// </summary>
        OnChangeCheckBox = 45,

        /// <summary>
        /// ПриВыводеСтроки.
        /// </summary>
        OnOutputRow = 47,

        /// <summary>
        /// ВыборЗначения.
        /// </summary>
        OnChoiceValue = 48,

        /// <summary>
        /// ПриОкончанииРедактирования.
        /// </summary>
        OnEndEdit = 49,

        /// <summary>
        /// ОбработкаЗаписиНовогоОбъекта.
        /// </summary>
        NewObjectWriteProcessing = 50,

        /// <summary>
        /// ПослеУдаления.
        /// </summary>
        AfterDeleteRow = 51,

        /// <summary>
        /// ОбработкаВыбора.
        /// </summary>
        ChoiceProcessing = 52,

        /// <summary>
        /// ПриПолученииДанных.
        /// </summary>
        OnGetData = 53,

        /// <summary>
        /// НачалоПеретаскивания.
        /// </summary>
        OnStartDragAndDrop = 900,

        /// <summary>
        /// ПроверкаПеретаскивания.
        /// </summary>
        OnCheckDragAndDrop = 901,

        /// <summary>
        /// ОкончаниеПеретаскивания.
        /// </summary>
        OnEndDragAndDropInSourceData = 902,

        /// <summary>
        /// Перетаскивание.
        /// </summary>
        OnEndDragAndDropInReceiverData = 903,
    }
}
