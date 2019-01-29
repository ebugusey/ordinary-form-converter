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
        public bool ChangePositionOfColumns { get; set; }

        /// <summary>
        /// ИзменятьПорядокСтрок.
        /// </summary>
        public bool ChangeRowOrder { get; set; }

        /// <summary>
        /// ИзменятьСоставСтрок.
        /// </summary>
        public bool ChangeRowSet { get; set; }

        /// <summary>
        /// ИзменятьНастройкуКолонок.
        /// </summary>
        public bool ChangeSettingOfColumns { get; set; }

        /// <summary>
        /// Колонки.
        /// </summary>
        public List<TableBoxColumn> Columns { get; }

        /// <summary>
        /// Оформление табличного поля.
        /// </summary>
        public TableBoxDecoration Decor { get; set; }

        /// <summary>
        /// АктивизироватьПоУмолчанию.
        /// </summary>
        public bool DefaultControl { get; set; }

        /// <summary>
        /// РазрешитьПеретаскивание.
        /// </summary>
        public bool EnableDrag { get; set; }

        /// <summary>
        /// РазрешитьНачалоПеретаскивания.
        /// </summary>
        public bool EnableStartDrag { get; set; }

        /// <summary>
        /// События табличного поля.
        /// </summary>
        public Events<TableBoxEvent> Events { get; set; }

        /// <summary>
        /// ФиксацияСлева.
        /// </summary>
        public int FixedLeft { get; set; }

        /// <summary>
        /// ФиксацияСправа.
        /// </summary>
        public int FixedRight { get; set; }

        /// <summary>
        /// Подвал.
        /// </summary>
        public bool Footer { get; set; }

        /// <summary>
        /// ВысотаПодвала.
        /// </summary>
        public int FooterHeight { get; set; }

        /// <summary>
        /// Шапка.
        /// </summary>
        public bool Header { get; set; }

        /// <summary>
        /// ВысотаШапки.
        /// </summary>
        public int HeaderHeight { get; set; }

        /// <summary>
        /// ГоризонтальнаяПолосаПрокрутки.
        /// </summary>
        public ScrollBarUse HorizontalScrollBar { get; set; }

        /// <summary>
        /// НачальноеОтображениеСписка.
        /// </summary>
        public InitialListView InitialListView { get; set; }

        /// <summary>
        /// Вывод.
        /// </summary>
        public UseOutput Output { get; set; }

        /// <summary>
        /// ТолькоПросмотр.
        /// </summary>
        public bool ReadOnly { get; set; }

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
        public ScrollBarUse VerticalScrollBar { get; set; }
    }
}
