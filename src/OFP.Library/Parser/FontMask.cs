using System;
using OFP.ObjectModel.Platform.Fonts;

namespace OFP.Parser
{
    /// <summary>
    /// Внутренняя маска, которую платформа использует для того,
    /// чтобы указать какие поля у шрифтов с типами
    /// <see cref="FontType.AutoFont"/>, <see cref="FontType.StyleItem"/>
    /// и <see cref="FontType.WindowsFont"/> переопределены.
    /// <para>
    /// Если поле переопределено, его значение должно быть в сериализованном
    /// шрифте. Если оно не переопределено, то его не будет в сериализованном
    /// представлении и парсер его должен пропустить.
    /// </para>
    /// </summary>
    [Flags]
    internal enum FontMask
    {
        None = 0,
        FaceName = 0x1,
        Size = 0x2,
        Bold = 0x4,
        Italic = 0x8,
        Underline = 0x10,
        Strikeout = 0x20,
        Scale = 0x200,
    }
}
