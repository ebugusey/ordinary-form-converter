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

        protected InvalidV8Container(string message1, string message2)
            : base($"{message1}\n{message2}")
        {

        }

        protected InvalidV8Container(string message1, string message2, Exception innerException)
            : base($"{message1}\n{message2}", innerException)
        {

        }
    }
}
