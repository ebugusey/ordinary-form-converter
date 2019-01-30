using System;
using System.Collections.Generic;
using System.Text;
using OFP.ObjectModel.Common;
using OFP.ObjectModel.Localization;
using OFP.ObjectModel.Platform.Pictures;

namespace OFP.ObjectModel.FormElements.Panels
{
    /// <summary>
    /// Страница панели.
    /// </summary>
    public class PanelPage
    {
        /// <summary>
        /// Имя.
        /// </summary>
        public Identifier Name { get; set; }

        /// <summary>
        /// Заголовок.
        /// </summary>
        public LocalizedString Title { get; set; }

        /// <summary>
        /// Подсказка.
        /// </summary>
        public LocalizedString ToolTip { get; set; }

        /// <summary>
        /// КартинкаЗаголовка.
        /// </summary>
        public Picture TitlePicture { get; set; }

        /// <summary>
        /// Видимость.
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// Доступность.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Дочерние элементы страницы.
        /// </summary>
        public List<Element> ChildItems { get; }
    }
}
