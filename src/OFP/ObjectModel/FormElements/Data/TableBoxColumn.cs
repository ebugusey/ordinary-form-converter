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
        public bool AutoCellHeight { get; set; }

        /// <summary>
        /// АвтоОтметкаНезаполненного.
        /// </summary>
        public bool AutoMarkIncomplete { get; set; }

        /// <summary>
        /// ВысотаЯчейки.
        /// </summary>
        public int CellHeight { get; set; }

        /// <summary>
        /// ИзменятьПозицию.
        /// </summary>
        public bool ChangePosition { get; set; }

        /// <summary>
        /// ИзменятьНастройку.
        /// </summary>
        public bool ChangeSetting { get; set; }

        /// <summary>
        /// ИзменятьВидимость.
        /// </summary>
        public bool ChangeVisible { get; set; }

        /// <summary>
        /// ТриСостоянияФлажка.
        /// </summary>
        public bool CheckBoxThreeState { get; set; }

        /// <summary>
        /// ДанныеФлажка.
        /// </summary>
        public bool CheckData { get; set; }

        /// <summary>
        /// ЭлементУправления.
        /// </summary>
        public Element Control { get; set; }

        /// <summary>
        /// Данные.
        /// </summary>
        public string DataPath { get; set; }

        /// <summary>
        /// Оформление колонки.
        /// </summary>
        public TableBoxColumnDecoration Decor { get; set; }

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
        public LocalizedString HeaderToolTip { get; set; }

        /// <summary>
        /// ГоризонтальноеПоложениеВКолонке.
        /// </summary>
        public HorizontalAlign HorizontalAlignInColumn { get; set; }

        /// <summary>
        /// Гиперссылка.
        /// </summary>
        public bool Hyperlink { get; set; }

        /// <summary>
        /// Положение.
        /// </summary>
        public ColumnLocation Location { get; set; }

        /// <summary>
        /// ВыделятьОтрицательные.
        /// </summary>
        public bool MarkNegatives { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ДанныеКартинки.
        /// </summary>
        public string PictureData { get; set; }

        /// <summary>
        /// ТолькоПросмотр.
        /// </summary>
        public bool ReadOnly { get; set; }

        /// <summary>
        /// ОтображатьИерархию.
        /// </summary>
        public bool ShowHierarchy { get; set; }

        /// <summary>
        /// ОтображатьВПодвале.
        /// </summary>
        public bool ShowInFooter { get; set; }

        /// <summary>
        /// ОтображатьВШапке.
        /// </summary>
        public bool ShowInHeader { get; set; }

        /// <summary>
        /// ИзменениеРазмера.
        /// </summary>
        public ColumnSizeChange SizeChange { get; set; }

        /// <summary>
        /// ПропускатьПриВводе.
        /// </summary>
        public bool SkipOnInput { get; set; }

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
        public bool Visible { get; set; }
    }
}
