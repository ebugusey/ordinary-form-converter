using System;

namespace libUnpack.Exceptions
{
    /// <summary>
    /// Базовый класс для исключений библиотеки.
    /// </summary>
    public abstract class InvalidV8Container : Exception
    {
        protected InvalidV8Container(string generalMessage, string specificMessage)
            : base($"{generalMessage}\n{specificMessage}")
        {

        }

        protected InvalidV8Container(string generalMessage, string specificMessage, Exception innerException)
            : base($"{generalMessage}\n{specificMessage}", innerException)
        {

        }
    }
}
