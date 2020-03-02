using System;
using OFP.ObjectModel.Common;

namespace OFP.ObjectModel.Platform.Pictures
{
    /// <summary>
    /// Картинка.
    /// </summary>
    public abstract class Picture
    {
        /// <summary>
        /// Вид.
        /// </summary>
        public abstract PictureType Type { get; }
    }

    /// <summary>
    /// Пустая картинка.
    /// </summary>
    public class EmptyPicture : Picture
    {
        /// <summary>
        /// Вид.
        /// </summary>
        public override PictureType Type => PictureType.Empty;
    }

    /// <summary>
    /// Абсолютная картинка.
    /// </summary>
    public class AbsolutePicture : Picture
    {
        /// <summary>
        /// Вид.
        /// </summary>
        public override PictureType Type => PictureType.Absolute;

        /// <summary>
        /// Двоичные данные картинки.
        /// </summary>
        public ReadOnlyMemory<byte> Value { get; set; }
    }

    /// <summary>
    /// Картинка из библиотеки картинок.
    /// </summary>
    public abstract class PictureFromLib : Picture
    {
        /// <summary>
        /// Вид.
        /// </summary>
        public override PictureType Type => PictureType.FromLib;

        /// <summary>
        /// Англоязычное имя картинки.
        /// </summary>
        public abstract Identifier Name { get; }
    }

    /// <summary>
    /// Картинка из библиотеки картинок платформы.
    /// </summary>
    /// <typeparam name="T">
    /// Тип значения, используемого платформой для идентификации картинки.
    /// </typeparam>
    public class StdPicture<T> : PictureFromLib where T : struct
    {
        /// <summary>
        /// Англоязычное имя картинки в библиотеке картинок.
        /// </summary>
        public override Identifier Name { get; }

        /// <summary>
        /// Значение, используемое платформой для идентификации картинки.
        /// </summary>
        public T Value { get; }

        public StdPicture(Identifier name, T value)
        {
            Name = name;
            Value = value;
        }

        public StdPicture(string name, T value)
            : this((Identifier)name, value)
        {
        }

        public override string ToString() => $"StdPicture.{Name}";
    }

    /// <summary>
    /// Картинка из библиотеки картинок конфигурации.
    /// </summary>
    public class PictureFromConfiguration : PictureFromLib
    {
        /// <summary>
        /// Имя картинки в конфигурации.
        /// </summary>
        public override Identifier Name { get; }

        /// <summary>
        /// Идентификатор картинки в конфигурации.
        /// </summary>
        public Guid Value { get; set; }
    }
}
