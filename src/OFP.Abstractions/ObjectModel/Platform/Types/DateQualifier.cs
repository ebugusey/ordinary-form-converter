namespace OFP.ObjectModel.Platform.Types
{
    /// <summary>
    /// КвалификаторыДаты.
    /// </summary>
    public class DateQualifier : TypeQualifier
    {
        public override PlatformType Type => PlatformType.Date;

        /// <summary>
        /// ЧастиДаты.
        /// </summary>
        public DateFraction Fractions { get; }

        public DateQualifier()
        {
            Fractions = DateFraction.DateAndTime;
        }

        public DateQualifier(DateFraction fractions)
        {
            Fractions = fractions;
        }
    }
}
