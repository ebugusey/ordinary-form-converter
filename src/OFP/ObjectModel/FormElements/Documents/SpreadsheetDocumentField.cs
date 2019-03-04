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
        public bool IsEnableDragAndDrop { get; set; }

        /// <summary>
        /// РазрешитьНачалоПеретаскивания.
        /// </summary>
        public bool IsEnableStartDragAndDrop { get; set; }

        /// <summary>
        /// События SpreadsheetDocumentField.
        /// </summary>
        public Events<SpreadsheetDocumentFieldEvent> Events { get; set; }

        /// <summary>
        /// ОтображатьВыделение.
        /// </summary>
        public SpreadsheetDocumentSelectionShowModeType SelectionShowModeType { get; set; }

        /// <summary>
        /// Вывод.
        /// </summary>
        public UseOutput OutputUse { get; set; }

        /// <summary>
        /// ГоризонтальнаяПолосаПрокрутки.
        /// </summary>
        public bool HasHorizontalScrollBar { get; set; }

        /// <summary>
        /// ВертикальнаяПолосаПрокрутки.
        /// </summary>
        public bool HasVerticalScrollBar { get; set; }
    }
}
