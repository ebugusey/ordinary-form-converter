using System;

namespace OFP.ObjectModel.FormElements.Data.Extensions
{
    public class ValueExtension<T> : ElementExtension
    {
        public override Guid Id => new Guid("9a7643d2-19e9-45e2-8893-280bc9195a97");

        /// <summary>
        /// МногострочныйРежим.
        /// </summary>
        public bool InMultiLineMode { get; set; }

        /// <summary>
        /// Маска.
        /// </summary>
        public string Mask { get; set; }

        /// <summary>
        /// РежимПароля.
        /// </summary>
        public bool InPasswordMode { get; set; }

        /// <summary>
        /// РасширенноеРедактирование.
        /// </summary>
        public bool IsExtendedEdit { get; set; }

        /// <summary>
        /// МинимальноеЗначение.
        /// </summary>
        public T MinValue { get; set; }

        /// <summary>
        /// МаксимальноеЗначение.
        /// </summary>
        public T MaxValue { get; set; }

        public ValueExtension()
        {
            Mask = string.Empty;
        }
    }
}
