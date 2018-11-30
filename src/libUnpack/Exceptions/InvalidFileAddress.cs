using System;

namespace libUnpack.Exceptions
{
    /// <summary>
    /// Исключение вызываемое, когда документ оглавления имеет неправильный формат.
    /// </summary>
    public class InvalidFileAddress : InvalidV8Container
    {
        private static readonly string DefaultMessage = "Ошибка при чтении адреса файла.";

        public InvalidFileAddress()
            : base(DefaultMessage)
        {

        }

        public InvalidFileAddress(Exception innerException)
            : base(DefaultMessage, innerException)
        {

        }
    }
}
