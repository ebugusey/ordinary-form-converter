using System.Collections.Generic;
using OFP.ObjectModel.Common;
using OFP.ObjectModel.Localization;
using OFP.ObjectModel.Platform;

namespace OFP.ObjectModel.FormElements.Actions
{
    /// <summary>
    /// Кнопка.
    /// </summary>
    class Button : Element
    {
        /// <summary>
        /// Заголовок.
        /// </summary>
        public LocalizedString Title { get; set; }

        /// <summary>
        /// КнопкаПоУмолчанию.
        /// </summary>
        public bool IsDefaultButton { get; set; }

        /// <summary>
        /// ИсточникДействий.
        /// </summary>
        public string ActionSource { get; set; }

        /// <summary>
        /// СочетаниеКлавиш.
        /// </summary>
        public Shortcut Shortcut { get; set; }

        /// <summary>
        /// РежимМеню.
        /// </summary>
        public UseMenuMode MenuMode { get; set; }

        /// <summary>
        /// ГоризонтальноеПоложение.
        /// </summary>
        public HorizontalAlign HorizontalAlign { get; set; }

        /// <summary>
        /// ВертикальноеПоложение.
        /// </summary>
        public VerticalAlign VerticalAlign { get; set; }

        /// <summary>
        /// МногострочныйРежим.
        /// </summary>
        public bool InMultiLineMode { get; set; }

        /// <summary>
        /// Оформление кнопки.
        /// </summary>
        public ButtonDecoration Decoration { get; set; }

        /// <summary>
        /// АктивизироватьПоУмолчанию.
        /// </summary>
        public bool ActivatedByDefault { get; set; }

        /// <summary>
        /// Дочерние элементы кнопки,
        /// заполняется если <c><see cref="MenuMode"/> != <see cref="UseMenuMode.DontUse"/></c>
        /// </summary>
        public List<CommandBarButton> ChildElements { get; set; }

        /// <summary>
        /// События кнопки.
        /// </summary>
        public Events<ButtonEvent> Events { get; set; }
    }
}
