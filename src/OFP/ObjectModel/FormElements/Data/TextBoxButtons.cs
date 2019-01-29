namespace OFP.ObjectModel.FormElements.Data
{
    /// <summary>
    /// Видимость кнопок поля ввода.
    /// </summary>
    public class TextBoxButtons
    {
        /// <summary>
        /// КнопкаВыбора.
        /// </summary>
        public bool HasChoiceButton { get; set; }

        /// <summary>
        /// КнопкаСпискаВыбора.
        /// </summary>
        public bool HasChoiceListButton { get; set; }

        /// <summary>
        /// КнопкаОчистки.
        /// </summary>
        public bool HasClearButton { get; set; }

        /// <summary>
        /// КнопкаОткрытия.
        /// </summary>
        public bool HasOpenButton { get; set; }

        /// <summary>
        /// КнопкаРегулирования.
        /// </summary>
        public bool HasSpinButton { get; set; }
    }
}
