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
        /// ТолькоПросмотр.
        /// </summary>
        public bool IsReadOnly { get; set; }

        /// <summary>
        /// ИзменятьСоставСтрок.
        /// </summary>
        public bool CanChangeRowSet { get; set; }

        /// <summary>
        /// РазрешитьНачалоПеретаскивания.
        /// </summary>
        public bool DragEnabled { get; set; }

        /// <summary>
        /// РазрешитьПеретаскивание.
        /// </summary>
        public bool DropEnabled { get; set; }

        /// <summary>
        /// ИзменятьНастройкуКолонок.
        /// </summary>
        public bool CanChangeSettingOfColumns { get; set; }

        /// <summary>
        /// ИзменятьПозициюКолонок.
        /// </summary>
        public bool CanChangePositionOfColumns { get; set; }

        /// <summary>
        /// Вывод.
        /// </summary>
        public UseOutput OutputMode { get; set; }

        /// <summary>
        /// ИзменятьПорядокСтрок.
        /// </summary>
        public bool CanChangeRowOrder { get; set; }

        /// <summary>
        /// РежимВводаСтрок.
        /// </summary>
        public TableBoxRowInputMode RowInputMode { get; set; }

        /// <summary>
        /// РежимВыделения.
        /// </summary>
        public TableBoxSelectionMode SelectionMode { get; set; }

        /// <summary>
        /// РежимВыделенияСтроки.
        /// </summary>
        public TableBoxRowSelectionMode RowSelectionMode { get; set; }

        /// <summary>
        /// Шапка.
        /// </summary>
        public bool HasHeader { get; set; }

        /// <summary>
        /// Подвал.
        /// </summary>
        public bool HasFooter { get; set; }

        /// <summary>
        /// ВысотаШапки.
        /// </summary>
        public ushort HeaderHeight { get; set; }

        /// <summary>
        /// ВысотаПодвала.
        /// </summary>
        public int FooterHeight { get; set; }

        /// <summary>
        /// ГоризонтальнаяПолосаПрокрутки.
        /// </summary>
        public ScrollBarUse HorizontalScrollBarMode { get; set; }

        /// <summary>
        /// ВертикальнаяПолосаПрокрутки.
        /// </summary>
        public ScrollBarUse VerticalScrollBarMode { get; set; }

        /// <summary>
        /// ФиксацияСлева.
        /// </summary>
        public ushort CountOfColumnsFixedLeft { get; set; }

        /// <summary>
        /// ФиксацияСправа.
        /// </summary>
        public ushort CountOfColumnsFixedRight { get; set; }

        /// <summary>
        /// АвтоВводНовойСтроки.
        /// </summary>
        public bool AutoInsertNewRow { get; set; }

        /// <summary>
        /// НачальноеОтображениеСписка.
        /// </summary>
        public InitialListView InitialListViewMode { get; set; }

        /// <summary>
        /// Оформление табличного поля.
        /// </summary>
        public TableBoxDecoration Decoration { get; set; }

        /// <summary>
        /// АктивизироватьПоУмолчанию.
        /// </summary>
        public bool ActivatedByDefault { get; set; }

        /// <summary>
        /// Колонки.
        /// </summary>
        public List<TableBoxColumn> Columns { get; set; }

        /// <summary>
        /// События табличного поля.
        /// </summary>
        public Events<TableBoxEvent> Events { get; set; }

        public TableBox()
        {
            CanChangeRowSet = true;

            CanChangeSettingOfColumns = true;
            CanChangePositionOfColumns = true;

            CanChangeRowOrder = true;

            HasHeader = true;

            HeaderHeight = 1;

            HorizontalScrollBarMode = ScrollBarUse.UseAuto;
            VerticalScrollBarMode = ScrollBarUse.UseAuto;

            InitialListViewMode = InitialListView.Auto;

            Decoration = new TableBoxDecoration();
            Events = new Events<TableBoxEvent>();

            Columns = new List<TableBoxColumn>();
        }
    }
}
