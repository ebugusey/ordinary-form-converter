using System;

namespace libUnpack.Exceptions
{
    /// <summary>
    /// Базовый класс для исключений библиотеки.
    /// </summary>
    public abstract class InvalidV8Container : Exception
    {
        protected InvalidV8Container(string message)
            : base(message)
        {
        }

        protected InvalidV8Container(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
