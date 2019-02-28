using OFP.ObjectModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.FormElements.Data
{
    /// <summary>
    /// ТабличноеПоле.
    /// </summary>
    public class TableBox : Element
    {
        /// <summary>
        /// АвтоВводНовойСтроки.
        /// </summary>
        public bool IsAutoInsertNewRow { get; set; }

        /// <summary>
        /// ИзменятьПозициюКолонок.
        /// </summary>
        public bool IsChangePositionOfColumns { get; set; }

        /// <summary>
        /// ИзменятьПорядокСтрок.
        /// </summary>
        public bool IsChangeRowOrder { get; set; }

        /// <summary>
        /// ИзменятьСоставСтрок.
        /// </summary>
        public bool IsChangeRowSet { get; set; }

        /// <summary>
        /// ИзменятьНастройкуКолонок.
        /// </summary>
        public bool IsChangeSettingOfColumns { get; set; }

        /// <summary>
        /// Колонки.
        /// </summary>
        public List<TableBoxColumn> Columns { get; }

        /// <summary>
        /// Оформление табличного поля.
        /// </summary>
        public TableBoxDecoration Decoration { get; set; }

        /// <summary>
        /// АктивизироватьПоУмолчанию.
        /// </summary>
        public bool IsActivateByDefault { get; set; }

        /// <summary>
        /// РазрешитьПеретаскивание.
        /// </summary>
        public bool IsEnableDragAndDrop { get; set; }

        /// <summary>
        /// РазрешитьНачалоПеретаскивания.
        /// </summary>
        public bool IsEnableStartDragAndDrop { get; set; }

        /// <summary>
        /// События табличного поля.
        /// </summary>
        public Events<TableBoxEvent> Events { get; set; }

        /// <summary>
        /// ФиксацияСлева.
        /// </summary>
        public int CountColumnsFixedLeft { get; set; }

        /// <summary>
        /// ФиксацияСправа.
        /// </summary>
        public int CountColomnsFixedRight { get; set; }

        /// <summary>
        /// Подвал.
        /// </summary>
        public bool HasFooter { get; set; }

        /// <summary>
        /// ВысотаПодвала.
        /// </summary>
        public int FooterHeight { get; set; }

        /// <summary>
        /// Шапка.
        /// </summary>
        public bool HasHeader { get; set; }

        /// <summary>
        /// ВысотаШапки.
        /// </summary>
        public int HeaderHeight { get; set; }

        /// <summary>
        /// ГоризонтальнаяПолосаПрокрутки.
        /// </summary>
        public ScrollBarUse HorizontalScrollBarUse { get; set; }

        /// <summary>
        /// НачальноеОтображениеСписка.
        /// </summary>
        public InitialListView InitialListViewMode { get; set; }

        /// <summary>
        /// Вывод.
        /// </summary>
        public UseOutput OutputUse { get; set; }

        /// <summary>
        /// ТолькоПросмотр.
        /// </summary>
        public bool IsReadOnly { get; set; }

        /// <summary>
        /// РежимВводаСтрок.
        /// </summary>
        public TableBoxRowInputMode RowInputMode { get; set; }

        /// <summary>
        /// РежимВыделенияСтроки.
        /// </summary>
        public TableBoxRowSelectionMode RowSelectionMode { get; set; }

        /// <summary>
        /// РежимВыделения.
        /// </summary>
        public TableBoxSelectionMode SelectionMode { get; set; }

        /// <summary>
        /// ВертикальнаяПолосаПрокрутки.
        /// </summary>
        public ScrollBarUse VerticalScrollBarUse { get; set; }
    }
}
