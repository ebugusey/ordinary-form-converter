using System;

namespace OFP.ObjectModel.Platform.Fonts
{
    /// <summary>
    /// Шрифт.
    /// </summary>
    public abstract class Font
    {
        /// <summary>
        /// Вид.
        /// </summary>
        public abstract FontType Type { get; }
    }

    /// <summary>
    /// Относительный шрифт. Указывается основание (стиль шрифта) и заполняются
    /// свойства, которые должны отличаться от указанного основания.
    /// </summary>
    public abstract class RelativeFont : Font
    {
        /// <summary>
        /// Имя.
        /// </summary>
        public string FaceName { get; set; }

        /// <summary>
        /// Размер.
        /// </summary>
        public ushort? Size { get; set; }

        /// <summary>
        /// Масштаб.
        /// </summary>
        public ushort? Scale { get; set; }

        /// <summary>
        /// Жирный.
        /// </summary>
        public bool? Bold { get; set; }

        /// <summary>
        /// Зачеркивание.
        /// </summary>
        public bool? Strikeout { get; set; }

        /// <summary>
        /// Наклонный.
        /// </summary>
        public bool? Italic { get; set; }

        /// <summary>
        /// Подчеркивание.
        /// </summary>
        public bool? Underline { get; set; }
    }

    /// <summary>
    /// Шрифт на базе стиля платформы или из конфигурации.
    /// </summary>
    /// <typeparam name="TStyle"></typeparam>
    public abstract class StyleBasedFont<TStyle> : RelativeFont where TStyle : struct
    {
        /// <summary>
        /// Стиль.
        /// </summary>
        public abstract TStyle Style { get; set; }
    }

    /// <summary>
    /// Шрифт ОС.
    /// </summary>
    public class WindowsFont : StyleBasedFont<WindowsFontStyle>
    {
        /// <summary>
        /// Вид.
        /// </summary>
        public override FontType Type => FontType.WindowsFont;

        /// <summary>
        /// Стиль.
        /// </summary>
        public override WindowsFontStyle Style { get; set; }
    }

    /// <summary>
    /// Стандартный шрифт платформы из библиотеки стилей.
    /// </summary>
    public class StandardFont : StyleBasedFont<StandardFontStyle>
    {
        /// <summary>
        /// Вид.
        /// </summary>
        public override FontType Type => FontType.StyleItem;

        /// <summary>
        /// Стиль.
        /// </summary>
        public override StandardFontStyle Style { get; set; }
    }

    /// <summary>
    /// Шрифт из библиотеки стилей конфигурации.
    /// </summary>
    public class FontFromConfiguration : StyleBasedFont<Guid>
    {
        /// <summary>
        /// Вид.
        /// </summary>
        public override FontType Type => FontType.StyleItem;

        /// <summary>
        /// Стиль.
        /// </summary>
        public override Guid Style { get; set; }
    }

    /// <summary>
    /// Авто-шрифт.
    /// </summary>
    public class AutoFont : RelativeFont
    {
        /// <summary>
        /// Вид.
        /// </summary>
        public override FontType Type => FontType.AutoFont;
    }

    /// <summary>
    /// Абсолютный шрифт.
    /// </summary>
    public class AbsoluteFont : Font
    {
        /// <summary>
        /// Вид.
        /// </summary>
        public override FontType Type => FontType.Absolute;

        /// <summary>
        /// Имя.
        /// </summary>
        public string FaceName { get; set; }

        /// <summary>
        /// Размер.
        /// </summary>
        public ushort Size { get; set; }

        /// <summary>
        /// Масштаб.
        /// </summary>
        public ushort Scale { get; set; }

        /// <summary>
        /// Жирный.
        /// </summary>
        public bool Bold { get; set; }

        /// <summary>
        /// Зачеркивание.
        /// </summary>
        public bool Strikeout { get; set; }

        /// <summary>
        /// Наклонный.
        /// </summary>
        public bool Italic { get; set; }

        /// <summary>
        /// Подчеркивание.
        /// </summary>
        public bool Underline { get; set; }
    }



}
