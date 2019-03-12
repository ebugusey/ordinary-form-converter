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
        OnTheNextRow = 1,

        /// <summary>
        /// ВТойЖеКолонке.
        /// </summary>
        InTheSameColumn = 2,
    }
}
