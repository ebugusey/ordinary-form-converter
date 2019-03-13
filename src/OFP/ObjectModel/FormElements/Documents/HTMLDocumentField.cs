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
        /// Вывод.
        /// </summary>
        public UseOutput OutputMode { get; set; }

        /// <summary>
        /// Оформление ПолеHTMLДокумента.
        /// </summary>
        public HTMLDocumentFieldDecoration Decoration { get; set; }

        /// <summary>
        /// АктивизироватьПоУмолчанию.
        /// </summary>
        public bool ActivetedByDefault { get; set; }

        /// <summary>
        /// События ПолеHTMLДокумента.
        /// </summary>
        public Events<HTMLDocumentFieldEvent> Events { get; set; }

        public HTMLDocumentField()
        {
            Decoration = new HTMLDocumentFieldDecoration();
            Events = new Events<HTMLDocumentFieldEvent>();
        }
    }
}
