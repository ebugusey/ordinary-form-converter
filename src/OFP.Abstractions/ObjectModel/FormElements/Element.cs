using OFP.ObjectModel.Localization;
using OFP.ObjectModel.Bindings;
using OFP.ObjectModel.Common;

namespace OFP.ObjectModel.FormElements
{
    /// <summary>
    /// Базовый класс для всех элементов формы.
    /// </summary>
    public abstract class Element
    {
        /// <summary>
        /// Имя.
        /// </summary>
        public Identifier Name { get; set; }

        /// <summary>
        /// Данные.
        /// </summary>
        public string DataPath { get; set; }

        /// <summary>
        /// ИзменяетДанные.
        /// </summary>
        public bool ModifiesData { get; set; }

        /// <summary>
        /// ПропускатьПриВводе.
        /// </summary>
        public bool SkipedOnInput { get; set; }

        /// <summary>
        /// ПервыйВГруппе.
        /// </summary>
        public bool IsFirstInGroupOfElements { get; set; }

        /// <summary>
        /// Видимость.
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// Доступность.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// АвтоКонтекстноеМеню.
        /// </summary>
        public bool AutoContextMenu { get; set; }

        /// <summary>
        /// Подсказка.
        /// </summary>
        public LocalizedString ToolTip { get; set; }

        /// <summary>
        /// Привязки.
        /// </summary>
        public BorderBindings? Bindings { get; set; }

        /// <summary>
        /// Расположение.
        /// </summary>
        public Position Position { get; set; }

        protected Element()
        {
            DataPath = string.Empty;

            Visible = true;
            Enabled = true;

            ToolTip = new LocalizedString();

            Position = new Position();
        }
    }
}
