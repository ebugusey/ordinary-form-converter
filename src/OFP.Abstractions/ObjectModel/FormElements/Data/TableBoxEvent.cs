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
        OnCheckBoxChange = 45,

        /// <summary>
        /// ПриВыводеСтроки.
        /// </summary>
        OnOutputRow = 47,

        /// <summary>
        /// ВыборЗначения.
        /// </summary>
        OnValueChoice = 48,

        /// <summary>
        /// ПриОкончанииРедактирования.
        /// </summary>
        OnEditEnd = 49,

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
        OnDataGet = 53,

        /// <summary>
        /// НачалоПеретаскивания.
        /// </summary>
        OnDrag = 900,

        /// <summary>
        /// ПроверкаПеретаскивания.
        /// </summary>
        OnDragAndDropCheck = 901,

        /// <summary>
        /// ОкончаниеПеретаскивания.
        /// </summary>
        OnDropInDataSourse = 902,

        /// <summary>
        /// Перетаскивание.
        /// </summary>
        OnDropInDataReceiver = 903,
    }
}
