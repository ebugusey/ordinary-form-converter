namespace OFP.ObjectModel.Forms
{
    /// <summary>
    /// События формы.
    /// </summary>
    public enum FormEvent
    {
        /// <summary>
        /// ПередОткрытием.
        /// </summary>
        BeforeOpen = 70000,

        /// <summary>
        /// ПриОткрытии.
        /// </summary>
        OnOpen = 70001,

        /// <summary>
        /// ПередЗакрытием.
        /// </summary>
        BeforeClose = 70002,

        /// <summary>
        /// ПриЗакрытии.
        /// </summary>
        OnClose = 70003,

        /// <summary>
        /// ОбработкаВыбора.
        /// </summary>
        ChoiceProcessing = 70004,

        /// <summary>
        /// ОбработкаАктивизацииОбъекта.
        /// </summary>
        ObjectActivationProcessing = 70005,

        /// <summary>
        /// ОбработкаЗаписиНовогоОбъекта.
        /// </summary>
        NewObjectWriteProcessing = 70006,

        /// <summary>
        /// ОбработкаОповещения.
        /// </summary>
        NotificationProcessing = 70007,

        /// <summary>
        /// ПриПовторномОткрытии.
        /// </summary>
        OnReopen = 70008,

        /// <summary>
        /// ОбновлениеОтображения.
        /// </summary>
        RefreshDisplay = 70009,

        /// <summary>
        /// ВнешнееСобытие.
        /// </summary>
        ExternalEvent = 70010,

        /// <summary>
        /// ОбработкаПроверкиЗаполнения.
        /// </summary>
        FillCheckProcessing = 70011,
    }
}
