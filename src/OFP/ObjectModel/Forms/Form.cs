using OFP.ObjectModel.Common;
using OFP.ObjectModel.FormElements;
using OFP.ObjectModel.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.Forms
{
    /// <summary>
    /// Форма обычного интерфейса.
    /// </summary>
    public class Form
    {
        /// <summary>
        /// Реквизиты формы.
        /// </summary>
        public List<Attribute> Attributes { get; }

        /// <summary>
        /// ПроверятьЗаполнениеАвтоматически.
        /// </summary>
        public bool HasAutoFillCheck { get; set; }

        /// <summary>
        /// АвтоЗаголовок.
        /// </summary>
        public bool HasAutoTitle { get; set; }

        /// <summary>
        /// Заголовок.
        /// </summary>
        public LocalizedString Title { get; set; }

        public bool CloseOnChoice { get; set; }
        public bool CloseOnOwnerClose { get; set; }

        /// <summary>
        /// Данные.
        /// </summary>
        public string NameData { get; set; }

        /// <summary>
        /// Оформление формы.
        /// </summary>
        public FormDecoration Decoration { get; set; }

        /// <summary>
        /// ПоведениеКлавишиEnter.
        /// </summary>
        public EnterKeyBehaviorType EnterKeyBehavior { get; set; }

        /// <summary>
        /// События формы.
        /// </summary>
        public Events<FormEvent> Events { get; set; }

        public bool ModalMode { get; set; }

        /// <summary>
        /// ВосстанавливатьЗначенияПриОткрытии.
        /// </summary>
        public bool IsRestoreValuesOnOpen { get; set; }

        /// <summary>
        /// Сохранять значения.
        /// </summary>
        public bool IsSaveValues { get; set; }

        /// <summary>
        /// Размеры формы.
        /// </summary>
        public Size Size { get; set; }
    }
}
