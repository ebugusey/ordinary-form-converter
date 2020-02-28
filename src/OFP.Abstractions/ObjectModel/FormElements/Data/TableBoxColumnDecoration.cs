using OFP.ObjectModel.Platform.Colors;
using OFP.ObjectModel.Platform.Fonts;
using OFP.ObjectModel.Platform.Pictures;

namespace OFP.ObjectModel.FormElements.Data
{
    /// <summary>
    /// Оформление колонки табличного поля.
    /// Представляет оформление одной из частей колонки: Шапки, Ячейки или Подвала.
    /// </summary>
    public class TableBoxColumnDecoration
    {
        /// <summary>
        /// ГоризонтальноеПоложениеВ...
        /// </summary>
        public HorizontalTextAlignment HorizontalAlign { get; set; }

        /// <summary>
        /// ЦветФона...
        /// </summary>
        public Color BackgroundColor { get; set; }

        /// <summary>
        /// ЦветТекста...
        /// </summary>
        public Color TextColor { get; set; }

        /// <summary>
        /// ШрифтТекста...
        /// </summary>
        public Font TextFont { get; set; }

        /// <summary>
        /// Картинка...
        /// </summary>
        public Picture Picture { get; set; }

        public TableBoxColumnDecoration()
        {
            HorizontalAlign = HorizontalTextAlignment.Auto;

            BackgroundColor = new AutoColor();
            TextColor = new AutoColor();

            TextFont = new AutoFont();

            Picture = new EmptyPicture();
        }
    }
}
