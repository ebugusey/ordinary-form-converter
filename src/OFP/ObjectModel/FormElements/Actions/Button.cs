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
        /// ИсточникДействий.
        /// </summary>
        public string ActionSource { get; set; }

        /// <summary>
        /// Заголовок.
        /// </summary>
        public LocalizedString Title { get; set; }

        /// <summary>
        /// КнопкаПоУмолчанию.
        /// </summary>
        public bool IsDefaultButton { get; set; }

        /// <summary>
        /// АктивизироватьПоУмолчанию.
        /// </summary>
        public bool IsActivateByDefault{ get; set; }

        /// <summary>
        /// МногострочныйРежим.
        /// </summary>
        public bool IsMultiLineMode { get; set; }

        /// <summary>
        /// ГоризонтальноеПоложение.
        /// </summary>
        public HorizontalAlign HorizontalAlign { get; set; }

        /// <summary>
        /// ВертикальноеПоложение.
        /// </summary>
        public VerticalAlign VerticalAlign { get; set; }

        /// <summary>
        /// РежимМеню.
        /// </summary>
        public UseMenuMode MenuMode { get; set; }

        /// <summary>
        /// Оформление кнопки.
        /// </summary>
        public ButtonDecoration Decoration { get; set; }

        /// <summary>
        /// СочетаниеКлавиш.
        /// </summary>
        public Shortcut KeyboardShortcut { get; set; }

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
