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
        OnCheckChange = 45,

        /// <summary>
        /// ПриВыводеСтроки.
        /// </summary>
        OnRowOutput = 47,

        /// <summary>
        /// ВыборЗначения.
        /// </summary>
        ValueChoice = 48,

        /// <summary>
        /// ПриОкончанииРедактирования.
        /// </summary>
        OnEditEnd = 49,

        /// <summary>
        /// ОбработкаЗаписиНовогоОбъекта.
        /// </summary>
        NewObjectWriteProcessing = 50,

        // FIXME: Row.
        /// <summary>
        /// ПослеУдаления.
        /// </summary>
        AfterDeleteLine = 51,

        /// <summary>
        /// ОбработкаВыбора.
        /// </summary>
        ChoiceProcessing = 52,

        /// <summary>
        /// ПриПолученииДанных.
        /// </summary>
        OnDataGet = 53,

        /// <summary>
        /// НачалоПеретаскивания.
        /// </summary>
        DragStart = 900,

        /// <summary>
        /// ПроверкаПеретаскивания.
        /// </summary>
        DragCheck = 901,

        /// <summary>
        /// ОкончаниеПеретаскивания.
        /// </summary>
        DragEnd = 902,

        /// <summary>
        /// Перетаскивание.
        /// </summary>
        Drag = 903,
    }
}
