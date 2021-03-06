using System.Collections.Generic;

namespace OFP.ObjectModel.FormElements.Actions
{
    /// <summary>
    /// КоманднаяПанель.
    /// </summary>
    public class CommandBar : Element
    {
        /// <summary>
        /// Вспомогательная.
        /// </summary>
        public bool IsSecondary { get; set; }

        /// <summary>
        /// АвтоЗаполнение.
        /// </summary>
        public bool IsAutoFill { get; set; }

        /// <summary>
        /// ИсточникДействий.
        /// </summary>
        public string ActionSource { get; set; }

        /// <summary>
        /// Ориентация.
        /// </summary>
        public Orientation Orientation { get; set; }

        /// <summary>
        /// ВыравниваниеКнопок.
        /// </summary>
        public CommandBarButtonAlignment ButtonsAlignment { get; set; }

        /// <summary>
        /// Оформление командной панели.
        /// </summary>
        public CommandBarDecoration Decoration { get; set; }

        /// <summary>
        /// АктивизироватьПоУмолчанию.
        /// </summary>
        public bool ActivatedByDefault { get; set; }

        /// <summary>
        /// Дочерние элементы (кнопки и подменю).
        /// </summary>
        public List<CommandBarButton> ChildItems { get; set; }

        public CommandBar()
        {
            ActionSource = string.Empty;

            Orientation = Orientation.Auto;

            Decoration = new CommandBarDecoration();

            ChildItems = new List<CommandBarButton>();
        }
    }
}
