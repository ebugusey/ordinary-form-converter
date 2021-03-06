using System.Collections.Generic;
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
        /// Выравнивающие линии.
        /// </summary>
        public List<AlignmentLine> AlignmentLines { get; set; }

        /// <summary>
        /// Дочерние элементы страницы.
        /// </summary>
        public List<Element> ChildItems { get; set; }

        public PanelPage()
        {
            Title = new LocalizedString();
            TitlePicture = new EmptyPicture();

            Visible = true;
            Enabled = true;

            AlignmentLines = new List<AlignmentLine>();

            ChildItems = new List<Element>();
        }
    }
}
