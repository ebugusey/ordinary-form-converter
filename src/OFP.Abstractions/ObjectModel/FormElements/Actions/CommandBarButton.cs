using System.Collections.Generic;
using OFP.ObjectModel.Common;
using OFP.ObjectModel.Localization;
using OFP.ObjectModel.Platform;
using OFP.ObjectModel.Platform.Pictures;

namespace OFP.ObjectModel.FormElements.Actions
{
    /// <summary>
    /// КнопкаКоманднойПанели.
    /// </summary>
    public class CommandBarButton
    {
        /// <summary>
        /// Имя.
        /// </summary>
        public Identifier Name { get; set; }

        /// <summary>
        /// ПорядокКнопок.
        /// </summary>
        public CommandBarButtonOrder ButtonOrder { get; set; }

        /// <summary>
        /// ТипКнопки.
        /// </summary>
        public CommandBarButtonType ButtonType { get; set; }

        /// <summary>
        /// Доступность.
        /// </summary>
        public bool Enabled { get; set; }

        // TODO: Добавить класс для описания действия.
        //      Действием может быть не только обработчик, но и стандартная команда.
        /// <summary>
        /// Действие.
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// КнопкаПоУмолчанию.
        /// </summary>
        public bool IsDefaultButton { get; set; }

        /// <summary>
        /// ИзменяетДанные.
        /// </summary>
        public bool ModifiesData { get; set; }

        /// <summary>
        /// Пометка.
        /// </summary>
        public bool Marked { get; set; }

        /// <summary>
        /// Текст.
        /// </summary>
        public LocalizedString Text { get; set; }

        /// <summary>
        /// Подсказка.
        /// </summary>
        public LocalizedString ToolTip { get; set; }

        /// <summary>
        /// Пояснение.
        /// </summary>
        public LocalizedString Description { get; set; }

        /// <summary>
        /// Картинка.
        /// </summary>
        public Picture Picture { get; set; }

        /// <summary>
        /// Отображение.
        /// </summary>
        public CommandBarButtonRepresentation Representation { get; set; }

        /// <summary>
        /// СочетаниеКлавиш.
        /// </summary>
        public Shortcut Shortcut { get; set; }

        /// <summary>
        /// Дочерние элементы кнопки.
        /// Заполняется если <c><see cref="ButtonType"/> == <see cref="CommandBarButtonType.Popup"/></c>.
        /// </summary>
        public List<CommandBarButton> ChildItems { get; set; }

        public CommandBarButton()
        {
            Enabled = true;

            Action = string.Empty;

            Text = new LocalizedString();
            ToolTip = new LocalizedString();
            Description = new LocalizedString();

            Picture = new EmptyPicture();

            ChildItems = new List<CommandBarButton>();
        }
    }
}
