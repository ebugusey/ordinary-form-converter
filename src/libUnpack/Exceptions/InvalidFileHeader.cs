using System;

namespace libUnpack.Exceptions
{
    /// <summary>
    /// Исключение вызываемое, когда документ заголовка файла имеет неправильный формат.
    /// </summary>
    public sealed class InvalidFileHeader : InvalidV8Container
    {
        private static readonly string DefaultMessage = "Ошибка при чтении заголовка файла.";

        public InvalidFileHeader()
            : base(DefaultMessage)
        {

        }

        public InvalidFileHeader(Exception innerException)
            : base(DefaultMessage, innerException)
        {

        }
    }
}
