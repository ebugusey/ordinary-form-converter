using OFP.ObjectModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.FormElements.Documents
{
    /// <summary>
    /// ПолеHTMLДокумента.
    /// </summary>
    public class HTMLDocumentField : Element
    {
        /// <summary>
        /// Оформление ПолеHTMLДокумента.
        /// </summary>
        public HTMLDocumentFieldDecoration Decor { get; set; }

        /// <summary>
        /// АктивизироватьПоУмолчанию.
        /// </summary>
        public bool DefaultControl { get; set; }

        /// <summary>
        /// События ПолеHTMLДокумента.
        /// </summary>
        public Events<HTMLDocumentFieldEvent> Events { get; set; }

        /// <summary>
        /// Вывод.
        /// </summary>
        public UseOutput Output { get; set; }
    }
}
