using OFP.ObjectModel.Localization;
using OFP.ObjectModel.Common;

namespace OFP.ObjectModel.FormElements.Decorative
{
    /// <summary>
    /// Надпись.
    /// </summary>
    public class Label : Element
    {
        /// <summary>
        /// Заголовок.
        /// </summary>
        public LocalizedString Title { get; set; }

        /// <summary>
        /// Гиперссылка.
        /// </summary>
        public bool IsHyperlink { get; set; }

        /// <summary>
        /// БегущаяСтрока.
        /// </summary>
        public ScrollingTextMode ScrollingTextMode { get; set; }

        /// <summary>
        /// Формат.
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// ВыделятьОтрицательные.
        /// </summary>
        public bool IsMarkNegativeNumbers { get; set; }

        /// <summary>
        /// Оформление надписи.
        /// </summary>
        public LabelDecoration Decoration { get; set; }

        /// <summary>
        /// События надписи.
        /// </summary>
        public Events<LabelEvent> Events { get; set; }

        public Label()
        {
            Title = new LocalizedString();

            Format = string.Empty;

            Decoration = new LabelDecoration();
            Events = new Events<LabelEvent>();
        }
    }
}
