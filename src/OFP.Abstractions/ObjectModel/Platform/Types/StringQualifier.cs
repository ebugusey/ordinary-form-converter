namespace OFP.ObjectModel.Platform.Types
{
    /// <summary>
    /// КвалификаторыСтроки.
    /// </summary>
    public class StringQualifier : TypeQualifier
    {
        public override PlatformType Type => PlatformType.String;

        /// <summary>
        /// Длина.
        /// </summary>
        public uint Length { get; }

        /// <summary>
        /// ДопустимаяДлина.
        /// </summary>
        public AllowedLength AllowedLength { get; }

        public StringQualifier()
        {
            AllowedLength = AllowedLength.Variable;
        }

        public StringQualifier(uint length, AllowedLength allowedLength)
        {
            (Length, AllowedLength) = (length, allowedLength);
        }
    }
}
