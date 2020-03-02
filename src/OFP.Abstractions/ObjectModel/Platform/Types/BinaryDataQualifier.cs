namespace OFP.ObjectModel.Platform.Types
{
    /// <summary>
    /// КвалификаторыДвоичныхДанных.
    /// </summary>
    public class BinaryDataQualifier : TypeQualifier
    {
        public override PlatformType Type => PlatformType.BinaryData;

        /// <summary>
        /// Длина.
        /// </summary>
        public uint Length { get; }

        /// <summary>
        /// ДопустимаяДлина.
        /// </summary>
        public AllowedLength AllowedLength { get; }

        public BinaryDataQualifier()
        {
            AllowedLength = AllowedLength.Variable;
        }

        public BinaryDataQualifier(uint length, AllowedLength allowedLength)
        {
            (Length, AllowedLength) = (length, allowedLength);
        }
    }
}
