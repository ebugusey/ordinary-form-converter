namespace OFP.ObjectModel.Platform.Types
{
    /// <summary>
    /// КвалификаторыЧисла.
    /// </summary>
    public class NumberQualifier : TypeQualifier
    {
        public override PlatformType Type => PlatformType.Number;

        /// <summary>
        /// ДопустимыйЗнак.
        /// </summary>
        public AllowedSign Sign { get; }

        /// <summary>
        /// Разрядность.
        /// </summary>
        public ushort Digits { get; }

        /// <summary>
        /// РазрядностьДробнойЧасти.
        /// </summary>
        public ushort FractionDigits { get; }

        public NumberQualifier()
        {

        }

        public NumberQualifier(AllowedSign sign, ushort digits, ushort fractionDigits)
        {
            (Sign, Digits, FractionDigits) = (sign, digits, fractionDigits);
        }
    }
}
