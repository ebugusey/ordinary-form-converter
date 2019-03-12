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
        public bool AutoInsertNewRow { get; set; }

        /// <summary>
        /// ИзменятьПозициюКолонок.
        /// </summary>
        public bool CanChangePositionOfColumns { get; set; }

        /// <summary>
        /// ИзменятьПорядокСтрок.
        /// </summary>
        public bool CanChangeRowOrder { get; set; }

        /// <summary>
        /// ИзменятьСоставСтрок.
        /// </summary>
        public bool CanChangeRowSet { get; set; }

        /// <summary>
        /// ИзменятьНастройкуКолонок.
        /// </summary>
        public bool CanChangeSettingOfColumns { get; set; }

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
        public bool ActivetedByDefault { get; set; }

        /// <summary>
        /// РазрешитьПеретаскивание.
        /// </summary>
        public bool DropEnabled { get; set; }

        /// <summary>
        /// РазрешитьНачалоПеретаскивания.
        /// </summary>
        public bool DragEnabled { get; set; }

        /// <summary>
        /// События табличного поля.
        /// </summary>
        public Events<TableBoxEvent> Events { get; set; }

        /// <summary>
        /// ФиксацияСлева.
        /// </summary>
        public int CountOfColumnsFixedLeft { get; set; }

        /// <summary>
        /// ФиксацияСправа.
        /// </summary>
        public int CountOfColomnsFixedRight { get; set; }

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
        public ScrollBarUse HorizontalScrollBarMode { get; set; }

        /// <summary>
        /// НачальноеОтображениеСписка.
        /// </summary>
        public InitialListView InitialListViewMode { get; set; }

        /// <summary>
        /// Вывод.
        /// </summary>
        public UseOutput OutputMode { get; set; }

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
        public ScrollBarUse VerticalScrollBarMode { get; set; }
    }
}
