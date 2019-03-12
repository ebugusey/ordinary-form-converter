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
        OnChoiceListButtonPress = 1,

        /// <summary>
        /// НачалоВыбора.
        /// </summary>
        OnChoiceStart = 2,

        /// <summary>
        /// Очистка.
        /// </summary>
        OnClear = 3,

        /// <summary>
        /// Регулирование.
        /// </summary>
        OnSpin = 4,

        /// <summary>
        /// Открытие.
        /// </summary>
        OnOpen = 5,

        /// <summary>
        /// ОбработкаВыбора.
        /// </summary>
        OnChoiceEnd = 7,

        /// <summary>
        /// ОкончаниеВводаТекста.
        /// </summary>
        OnTextEditEnd = 10,

        /// <summary>
        /// АвтоПодборТекста.
        /// </summary>
        OnTextAutoComplete = 11,

        /// <summary>
        /// ПриИзменении.
        /// </summary>
        OnChange = 2147483647,
    }
}
