using System;

namespace libUnpack.Exceptions
{
    /// <summary>
    /// Исключение вызываемое, когда заголовок контейнера имеет неправильный формат.
    /// </summary>
    public sealed class InvalidContainerHeader : InvalidV8Container
    {
        private static readonly string DefaultMessage = "Ошибка при чтении заголовка контейнера.";

        public InvalidContainerHeader()
            : base(DefaultMessage)
        {

        }

        public InvalidContainerHeader(Exception innerException)
            : base(DefaultMessage, innerException)
        {

        }
    }
}
