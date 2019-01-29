using System.Collections.Generic;
using OFP.ObjectModel.Common;

namespace OFP.ObjectModel.FormElements.Actions
{
    /// <summary>
    /// КоманднаяПанель.
    /// </summary>
    public class CommandBar : Element
    {
        /// <summary>
        /// ИсточникДействий.
        /// </summary>
        public string ActionSource { get; set; }

        /// <summary>
        /// АктивизироватьПоУмолчанию.
        /// </summary>
        public bool DefaultControl { get; set; }

        /// <summary>
        /// Вспомогательная.
        /// </summary>
        public bool Secondary { get; set; }

        /// <summary>
        /// АвтоЗаполнение.
        /// </summary>
        public bool AutoFill { get; set; }

        /// <summary>
        /// Оформление командной панели.
        /// </summary>
        public CommandBarDecoration Decor { get; set; }

        /// <summary>
        /// Ориентация.
        /// </summary>
        public Orientation Orientation { get; set; }

        /// <summary>
        /// ВыравниваниеКнопок.
        /// </summary>
        public CommandBarButtonAlignment ButtonsAlignment { get; set; }

        /// <summary>
        /// Дочерние элементы (кнопки и подменю).
        /// </summary>
        public List<CommandBarButton> ChildElements { get; set; }
    }
}
