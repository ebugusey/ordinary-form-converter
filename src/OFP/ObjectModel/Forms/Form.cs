using OFP.ObjectModel.Common;
using OFP.ObjectModel.FormElements;
using OFP.ObjectModel.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.Forms
{
    //FIXME: Нет свойств: Сохраняемые значения, Окно (Window).
    /// <summary>
    /// Форма обычного интерфейса.
    /// </summary>
    public class Form
    {
        /// <summary>
        /// Заголовок.
        /// </summary>
        public LocalizedString Title { get; set; }

        /// <summary>
        /// ПоведениеКлавишиEnter.
        /// </summary>
        public EnterKeyBehaviorType EnterKeyBehavior { get; set; }

        /// <summary>
        /// Данные.
        /// </summary>
        public string DataPath { get; set; }

        /// <summary>
        /// АвтоЗаголовок.
        /// </summary>
        public bool AutoTitleEnabled { get; set; }

        /// <summary>
        /// Сохранять значения.
        /// </summary>
        public bool SavingValuesEnabled { get; set; }

        /// <summary>
        /// ВосстанавливатьЗначенияПриОткрытии.
        /// </summary>
        public bool RestoreValuesOnOpen { get; set; }

        /// <summary>
        /// Размеры формы.
        /// </summary>
        public Size Size { get; set; }

        /// <summary>
        /// ПроверятьЗаполнениеАвтоматически.
        /// </summary>
        public bool AutoCheckForBlankFields { get; set; }

        //FIXME: Надо удалить свойство.
        public bool CloseOnChoice { get; set; }
        //FIXME: Надо удалить свойство.
        public bool CloseOnOwnerClose { get; set; }

        /// <summary>
        /// Оформление формы.
        /// </summary>
        public FormDecoration Decoration { get; set; }

        //FIXME: Надо удалить свойство.
        public bool ModalMode { get; set; }

        /// <summary>
        /// Реквизиты формы.
        /// </summary>
        public List<Attribute> Attributes { get; set; }

        /// <summary>
        /// События формы.
        /// </summary>
        public Events<FormEvent> Events { get; set; }

        public Form()
        {
            Title = new LocalizedString();

            EnterKeyBehavior = EnterKeyBehaviorType.ControlNavigation;

            DataPath = string.Empty;

            AutoTitleEnabled = true;

            RestoreValuesOnOpen = true;

            Size = new Size();

            Decoration = new FormDecoration();
            Events = new Events<FormEvent>();

            Attributes = new List<Attribute>();
        }
    }
}
