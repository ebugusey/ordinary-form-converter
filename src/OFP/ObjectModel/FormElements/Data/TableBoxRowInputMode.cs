namespace OFP.ObjectModel.FormElements.Data
{
    /// <summary>
    /// РежимВводаСтрокТабличногоПоля.
    /// </summary>
    public enum TableBoxRowInputMode
    {
        /// <summary>
        /// ВКонецСписка.
        /// </summary>
        AtTheEndOfList = 0,

        /// <summary>
        /// ВКонецОкна.
        /// </summary>
        AtTheEndOfWindow = 1,

        /// <summary>
        /// ПослеТекущейСтроки.
        /// </summary>
        AfterCurrentRow = 2,

        /// <summary>
        /// ПередТекущейСтрокой.
        /// </summary>
        BeforeCurrentRow = 3,
    }
}
