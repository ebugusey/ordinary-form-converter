using System;

namespace libUnpack.Exceptions
{
    /// <summary>
    /// Исключение вызываемое, когда документ оглавления имеет неправильный формат.
    /// </summary>
    public class InvalidFileAddress : InvalidV8Container
    {
        private static readonly string DefaultMessage = "Ошибка при чтении адреса файла.";

        internal InvalidFileAddress(string message)
            : base(DefaultMessage, message)
        {

        }

        internal InvalidFileAddress(string message, Exception innerException)
            : base(DefaultMessage, message, innerException)
        {

        }
    }
}
