using System;

namespace OFP.ObjectModel.Platform.Colors
{
    /// <summary>
    /// Цвет.
    /// </summary>
    public abstract class Color
    {
        /// <summary>
        /// Вид.
        /// </summary>
        public abstract ColorType Type { get; }
    }

    /// <summary>
    /// Авто-цвет.
    /// </summary>
    public class AutoColor : Color
    {
        /// <summary>
        /// Вид.
        /// </summary>
        public override ColorType Type => ColorType.AutoColor;
    }

    /// <summary>
    /// Абсолютный цвет.
    /// </summary>
    public class AbsoluteColor : Color
    {
        /// <summary>
        /// Вид.
        /// </summary>
        public override ColorType Type => ColorType.Absolute;

        /// <summary>
        /// Красный.
        /// </summary>
        public byte Red { get; set; }

        /// <summary>
        /// Зеленый.
        /// </summary>
        public byte Green { get; set; }

        /// <summary>
        /// Синий.
        /// </summary>
        public byte Blue { get; set; }
    }

    /// <summary>
    /// Цвет на базе стиля платформы или конфигурации.
    /// </summary>
    /// <typeparam name="TStyle"></typeparam>
    public abstract class StyleBasedColor<TStyle> : Color where TStyle : struct
    {
        /// <summary>
        /// Стиль.
        /// </summary>
        public abstract TStyle Style { get; set; }
    }

    /// <summary>
    /// Цвет ОС.
    /// </summary>
    public class WindowsColor : StyleBasedColor<WindowsColorStyle>
    {
        /// <summary>
        /// Вид.
        /// </summary>
        public override ColorType Type => ColorType.WindowsColor;

        /// <summary>
        /// Стиль.
        /// </summary>
        public override WindowsColorStyle Style { get; set; }
    }

    /// <summary>
    /// Web-цвет.
    /// </summary>
    public class WebColor : StyleBasedColor<WebColorStyle>
    {
        /// <summary>
        /// Вид.
        /// </summary>
        public override ColorType Type => ColorType.WebColor;

        /// <summary>
        /// Стиль.
        /// </summary>
        public override WebColorStyle Style { get; set; }
    }

    /// <summary>
    /// Стандартный цвет платформы из библиотеки стилей.
    /// </summary>
    public class StandardColor : StyleBasedColor<StandardColorStyle>
    {
        /// <summary>
        /// Вид.
        /// </summary>
        public override ColorType Type => ColorType.StyleItem;

        /// <summary>
        /// Стиль.
        /// </summary>
        public override StandardColorStyle Style { get; set; }
    }

    /// <summary>
    /// Цвет из библиотеки стилей конфигурации.
    /// </summary>
    public class ColorFromConfiguration : StyleBasedColor<Guid>
    {
        /// <summary>
        /// Вид.
        /// </summary>
        public override ColorType Type => ColorType.StyleItem;

        /// <summary>
        /// Стиль.
        /// </summary>
        public override Guid Style { get; set; }
    }
}
