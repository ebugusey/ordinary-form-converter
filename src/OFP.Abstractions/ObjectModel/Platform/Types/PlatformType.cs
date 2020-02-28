namespace OFP.ObjectModel.Platform.Types
{
    /// <summary>
    /// Примитивный тип платформы.
    /// </summary>
    public enum PlatformType
    {
        /// <summary>
        /// Неопределено.
        /// </summary>
        Undefined,

        /// <summary>
        /// Строка.
        /// </summary>
        String,

        /// <summary>
        /// Число.
        /// </summary>
        Number,

        /// <summary>
        /// Булево.
        /// </summary>
        Boolean,

        /// <summary>
        /// Дата.
        /// </summary>
        Date,

        /// <summary>
        /// ДвоичныеДанные.
        /// </summary>
        BinaryData,

        /// <summary>
        /// ЛюбаяСсылка.
        /// </summary>
        Ref,
    }
}
