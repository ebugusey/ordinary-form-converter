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
        public bool DefaultButton { get; set; }

        /// <summary>
        /// АктивизироватьПоУмолчанию.
        /// </summary>
        public bool DefaultControl { get; set; }

        /// <summary>
        /// МногострочныйРежим.
        /// </summary>
        public bool MultiLine { get; set; }

        /// <summary>
        /// РежимМеню.
        /// </summary>
        public UseMenuMode MenuMode { get; set; }

        /// <summary>
        /// Оформление кнопки.
        /// </summary>
        public ButtonDecoration Decor { get; set; }

        /// <summary>
        /// СочетаниеКлавиш.
        /// </summary>
        public Shortcut Shortcut { get; set; }

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
