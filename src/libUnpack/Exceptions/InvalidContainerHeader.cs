using System;

namespace libUnpack.Exceptions
{
    /// <summary>
    /// Исключение вызываемое, когда заголовок контейнера имеет неправильный формат.
    /// </summary>
    public sealed class InvalidContainerHeader : InvalidV8Container
    {
        private static readonly string DefaultMessage = "Ошибка при чтении заголовка контейнера.";

        internal InvalidContainerHeader(string message)
            : base(DefaultMessage, message)
        {

        }

        internal InvalidContainerHeader(string message, Exception innerException)
            : base(DefaultMessage, message, innerException)
        {

        }
    }
}
