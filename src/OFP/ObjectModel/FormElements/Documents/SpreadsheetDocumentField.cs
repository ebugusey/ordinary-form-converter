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
        public SpreadsheetDocumentFieldDecoration Decor { get; set; }

        /// <summary>
        /// РазрешитьПеретаскивание.
        /// </summary>
        public bool EnableDrag { get; set; }

        /// <summary>
        /// РазрешитьНачалоПеретаскивания.
        /// </summary>
        public bool EnableStartDrag { get; set; }

        /// <summary>
        /// События SpreadsheetDocumentField.
        /// </summary>
        public Events<SpreadsheetDocumentFieldEvent> Events { get; set; }

        /// <summary>
        /// ОтображатьВыделение.
        /// </summary>
        public SpreadsheetDocumentSelectionShowModeType ShowSelection { get; set; }

        /// <summary>
        /// Вывод.
        /// </summary>
        public UseOutput Output { get; set; }

        /// <summary>
        /// ГоризонтальнаяПолосаПрокрутки.
        /// </summary>
        public bool HorizontalScrollBar { get; set; }

        /// <summary>
        /// ВертикальнаяПолосаПрокрутки.
        /// </summary>
        public bool VerticalScrollBar { get; set; }
    }
}
