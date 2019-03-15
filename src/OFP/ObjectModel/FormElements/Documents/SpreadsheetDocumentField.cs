using OFP.ObjectModel.Common;

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
        /// ВертикальнаяПолосаПрокрутки.
        /// </summary>
        public bool VerticalScrollBarVisible { get; set; }

        /// <summary>
        /// ГоризонтальнаяПолосаПрокрутки.
        /// </summary>
        public bool HorizontalScrollBarVisible { get; set; }

        /// <summary>
        /// РазрешитьНачалоПеретаскивания.
        /// </summary>
        public bool DragEnabled { get; set; }

        /// <summary>
        /// РазрешитьПеретаскивание.
        /// </summary>
        public bool DropEnabled { get; set; }

        /// <summary>
        /// ОтображатьВыделение.
        /// </summary>
        public SpreadsheetDocumentSelectionShowModeType SelectionViewMode { get; set; }

        /// <summary>
        /// Вывод.
        /// </summary>
        public UseOutput OutputMode { get; set; }

        /// <summary>
        /// События SpreadsheetDocumentField.
        /// </summary>
        public Events<SpreadsheetDocumentFieldEvent> Events { get; set; }

        public SpreadsheetDocumentField()
        {
            VerticalScrollBarVisible = true;
            HorizontalScrollBarVisible = true;

            Decoration = new SpreadsheetDocumentFieldDecoration();
            Events = new Events<SpreadsheetDocumentFieldEvent>();
        }
    }
}
