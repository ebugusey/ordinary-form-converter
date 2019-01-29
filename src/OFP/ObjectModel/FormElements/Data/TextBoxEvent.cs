namespace OFP.ObjectModel.FormElements.Data
{
    /// <summary>
    /// События поля ввода.
    /// </summary>
    public enum TextBoxEvent
    {
        /// <summary>
        /// НачалоВыбораИзСписка.
        /// </summary>
        StartListChoice = 1,

        /// <summary>
        /// НачалоВыбора.
        /// </summary>
        StartChoice = 2,

        /// <summary>
        /// Очистка.
        /// </summary>
        Clearing = 3,

        /// <summary>
        /// Регулирование.
        /// </summary>
        Tuning = 4,

        /// <summary>
        /// Открытие.
        /// </summary>
        Opening = 5,

        /// <summary>
        /// ОбработкаВыбора.
        /// </summary>
        ChoiceProcessing = 7,

        /// <summary>
        /// ОкончаниеВводаТекста.
        /// </summary>
        TextEditEnd = 10,

        /// <summary>
        /// АвтоПодборТекста.
        /// </summary>
        AutoCompleteText = 11,

        /// <summary>
        /// ПриИзменении.
        /// </summary>
        OnChange = 2147483647,
    }
}
