using System;

namespace libUnpack.Exceptions
{
    /// <summary>
    /// Исключение вызываемое, когда заголовок страницы документа имеет неправильный формат.
    /// </summary>
    public sealed class InvalidPageHeader : InvalidV8Container
    {
        private static readonly string DefaultMessage = "Ошибка при чтении заголовка страницы.";

        public InvalidPageHeader()
            : base(DefaultMessage)
        {

        }

        public InvalidPageHeader(Exception innerException)
            : base(DefaultMessage, innerException)
        {

        }
    }
}
