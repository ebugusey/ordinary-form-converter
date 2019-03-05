using System;
using System.Collections.Generic;
using System.Text;
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
        /// АвтоКонтекстноеМеню.
        /// </summary>
        public bool AutoContextMenu { get; set; }

        /// <summary>
        /// Привязки.
        /// </summary>
        public BorderBindings Bindings { get; set; }

        /// <summary>
        /// Данные.
        /// </summary>
        public string NameData { get; set; }

        /// <summary>
        /// Доступность.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Видимость.
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// ПервыйВГруппе.
        /// </summary>
        public bool IsFirstInGroupElements { get; set; }

        /// <summary>
        /// ИзменяетДанные.
        /// </summary>
        public bool IsModifiesData { get; set; }

        /// <summary>
        /// ПропускатьПриВводе.
        /// </summary>
        public bool IsSkipOnInput { get; set; }

        /// <summary>
        /// Подсказка.
        /// </summary>
        public LocalizedString ToolTip { get; set; }

        /// <summary>
        /// Расположение.
        /// </summary>
        public Position Position { get; set; }
    }
}
