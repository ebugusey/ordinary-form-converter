namespace OFP.ObjectModel.FormElements.Data
{
    /// <summary>
    /// ПоложениеКолонки.
    /// </summary>
    public enum ColumnLocation
    {
        /// <summary>
        /// НоваяКолонка.
        /// </summary>
        NewColumn = 0,

        /// <summary>
        /// НаСледующейСтроке.
        /// </summary>
        OnNextRow = 1,

        /// <summary>
        /// ВТойЖеКолонке.
        /// </summary>
        InSameColumn = 2,
    }
}
