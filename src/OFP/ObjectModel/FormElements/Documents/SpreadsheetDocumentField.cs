using OFP.ObjectModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.FormElements.Documents
{
    /// <summary>
    /// ПолеТабличногоДокумента.
    /// </summary>
    public class SpreadsheetDocumentField : Element
    {
        /// <summary>
        /// Оформление ПолеТабличногоДокумента.
        /// </summary>
        public SpreadsheetDocumentFieldDecoration Decoration { get; set; }

        /// <summary>
        /// РазрешитьПеретаскивание.
        /// </summary>
        public bool DropEnabled { get; set; }

        /// <summary>
        /// РазрешитьНачалоПеретаскивания.
        /// </summary>
        public bool DragEnabled { get; set; }

        /// <summary>
        /// События SpreadsheetDocumentField.
        /// </summary>
        public Events<SpreadsheetDocumentFieldEvent> Events { get; set; }

        /// <summary>
        /// ОтображатьВыделение.
        /// </summary>
        public SpreadsheetDocumentSelectionShowModeType SelectionViewMode { get; set; }

        /// <summary>
        /// Вывод.
        /// </summary>
        public UseOutput OutputMode { get; set; }

        /// <summary>
        /// ГоризонтальнаяПолосаПрокрутки.
        /// </summary>
        public bool HorizontalScrollBarVisible { get; set; }

        /// <summary>
        /// ВертикальнаяПолосаПрокрутки.
        /// </summary>
        public bool VerticalScrollBarVisible { get; set; }
    }
}
