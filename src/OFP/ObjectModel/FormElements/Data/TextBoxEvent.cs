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
        OnActivateChoiceListButton = 1,

        /// <summary>
        /// НачалоВыбора.
        /// </summary>
        OnStartChoice = 2,

        /// <summary>
        /// Очистка.
        /// </summary>
        OnActivateClearButton = 3,

        /// <summary>
        /// Регулирование.
        /// </summary>
        OnActivateSpinButton = 4,

        /// <summary>
        /// Открытие.
        /// </summary>
        OnActivateOpenButton = 5,

        /// <summary>
        /// ОбработкаВыбора.
        /// </summary>
        ChoiceProcessing = 7,

        /// <summary>
        /// ОкончаниеВводаТекста.
        /// </summary>
        OnEndTextEdit= 10,

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
