using OFP.ObjectModel.Common;
using OFP.ObjectModel.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.FormElements.Data
{
    /// <summary>
    /// КолонкаТабличногоПоля.
    /// </summary>
    public class TableBoxColumn
    {
        /// <summary>
        /// АвтоВысотаЯчейки.
        /// </summary>
        public bool IsAutoCellHeight { get; set; }

        /// <summary>
        /// АвтоОтметкаНезаполненного.
        /// </summary>
        public bool IsAutoBlankMark { get; set; }

        /// <summary>
        /// ВысотаЯчейки.
        /// </summary>
        public int CellHeight { get; set; }

        /// <summary>
        /// ИзменятьПозицию.
        /// </summary>
        public bool IsChangePosition { get; set; }

        /// <summary>
        /// ИзменятьНастройку.
        /// </summary>
        public bool IsChangeSetting { get; set; }

        /// <summary>
        /// ИзменятьВидимость.
        /// </summary>
        public bool IsChangeVisible { get; set; }

        /// <summary>
        /// ТриСостоянияФлажка.
        /// </summary>
        public bool HasThreeStatesCheckBox { get; set; }

        /// <summary>
        /// ДанныеФлажка.
        /// </summary>
        public bool IsCheckBoxData { get; set; }

        /// <summary>
        /// ЭлементУправления.
        /// </summary>
        public Element ControlElement { get; set; }

        /// <summary>
        /// Данные.
        /// </summary>
        public string NameDataColumn { get; set; }

        /// <summary>
        /// Оформление колонки.
        /// </summary>
        public TableBoxColumnDecoration Decoration { get; set; }

        /// <summary>
        /// РежимРедактирования.
        /// </summary>
        public ColumnEditMode EditMode { get; set; }

        /// <summary>
        /// Доступность.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// ГоризонтальноеПоложениеВПодвале.
        /// </summary>
        public HorizontalAlign FooterHorizontalAlign { get; set; }

        /// <summary>
        /// ГоризонтальноеПоложениеВШапке.
        /// </summary>
        public HorizontalAlign HeaderHorizontalAlign { get; set; }

        /// <summary>
        /// ПодсказкаВШапке.
        /// </summary>
        public LocalizedString HeaderToolTipText { get; set; }

        /// <summary>
        /// ГоризонтальноеПоложениеВКолонке.
        /// </summary>
        public HorizontalAlign HorizontalAlignInColumn { get; set; }

        /// <summary>
        /// Гиперссылка.
        /// </summary>
        public bool IsHyperlink { get; set; }

        /// <summary>
        /// Положение.
        /// </summary>
        public ColumnLocation Position { get; set; }

        /// <summary>
        /// ВыделятьОтрицательные.
        /// </summary>
        public bool IsMarkNegativeNumbers { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public Identifier Name { get; set; }

        /// <summary>
        /// ДанныеКартинки.
        /// </summary>
        public string PictureData { get; set; }

        /// <summary>
        /// ТолькоПросмотр.
        /// </summary>
        public bool IsReadOnly { get; set; }

        /// <summary>
        /// ОтображатьИерархию.
        /// </summary>
        public bool IsShowHierarchy { get; set; }

        /// <summary>
        /// ОтображатьВПодвале.
        /// </summary>
        public bool IsShowFooter { get; set; }

        /// <summary>
        /// ОтображатьВШапке.
        /// </summary>
        public bool IsShowHeader { get; set; }

        /// <summary>
        /// ИзменениеРазмера.
        /// </summary>
        public ColumnSizeChange SizeChangeMode { get; set; }

        /// <summary>
        /// ПропускатьПриВводе.
        /// </summary>
        public bool IsSkipOnInput { get; set; }

        /// <summary>
        /// ТекстПодвала.
        /// </summary>
        public LocalizedString FooterText { get; set; }

        /// <summary>
        /// ТекстШапки.
        /// </summary>
        public LocalizedString HeaderText { get; set; }

        /// <summary>
        /// Видимость.
        /// </summary>
        public bool IsVisible { get; set; }
    }
}
