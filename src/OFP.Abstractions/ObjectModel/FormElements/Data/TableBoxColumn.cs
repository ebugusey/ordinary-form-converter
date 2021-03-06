using OFP.ObjectModel.Common;
using OFP.ObjectModel.Localization;

namespace OFP.ObjectModel.FormElements.Data
{
    /// <summary>
    /// КолонкаТабличногоПоля.
    /// </summary>
    public class TableBoxColumn
    {
        /// <summary>
        /// Имя.
        /// </summary>
        public Identifier Name { get; set; }

        /// <summary>
        /// Данные.
        /// </summary>
        public string DataPath { get; set; }

        /// <summary>
        /// ЭлементУправления.
        /// </summary>
        public Element Control { get; set; }

        /// <summary>
        /// ДанныеФлажка.
        /// </summary>
        public string CheckBoxDataPath { get; set; }

        /// <summary>
        /// ДанныеКартинки.
        /// </summary>
        public string PictureData { get; set; }

        /// <summary>
        /// Доступность.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Видимость.
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// ТолькоПросмотр.
        /// </summary>
        public bool IsReadOnly { get; set; }

        /// <summary>
        /// ТекстШапки.
        /// </summary>
        public LocalizedString HeaderText { get; set; }

        /// <summary>
        /// ТекстПодвала.
        /// </summary>
        public LocalizedString FooterText { get; set; }

        /// <summary>
        /// Гиперссылка.
        /// </summary>
        public bool IsHyperlink { get; set; }

        /// <summary>
        /// АвтоОтметкаНезаполненного.
        /// </summary>
        public bool AutoMarkBlank { get; set; }

        /// <summary>
        /// ВыделятьОтрицательные.
        /// </summary>
        public bool IsMarkNegativeNumbers { get; set; }

        /// <summary>
        /// ТриСостоянияФлажка.
        /// </summary>
        public bool HasThreeStatesCheckBox { get; set; }

        /// <summary>
        /// Положение.
        /// </summary>
        public ColumnLocation Position { get; set; }

        /// <summary>
        /// ПодсказкаВШапке.
        /// </summary>
        public LocalizedString HeaderToolTip { get; set; }

        /// <summary>
        /// ОтображатьВШапке.
        /// </summary>
        public bool VisibleInHeader { get; set; }

        /// <summary>
        /// ОтображатьВПодвале.
        /// </summary>
        public bool VisibleInFooter { get; set; }

        /// <summary>
        /// ОтображатьИерархию.
        /// </summary>
        public bool HierarchyVisible { get; set; }

        /// <summary>
        /// РежимРедактирования.
        /// </summary>
        public ColumnEditMode EditMode { get; set; }

        /// <summary>
        /// АктивизироватьПоУмолчанию.
        /// </summary>
        public bool ActivatedByDefault { get; set; }

        /// <summary>
        /// ИзменениеРазмера.
        /// </summary>
        public ColumnSizeChange SizeChangeMode { get; set; }

        /// <summary>
        /// ИзменятьВидимость.
        /// </summary>
        public bool CanChangeVisible { get; set; }

        /// <summary>
        /// ИзменятьНастройку.
        /// </summary>
        public bool CanChangeSetting { get; set; }

        /// <summary>
        /// ИзменятьПозицию.
        /// </summary>
        public bool CanChangePosition { get; set; }

        /// <summary>
        /// ПропускатьПриВводе.
        /// </summary>
        public bool IsSkipOnInput { get; set; }

        /// <summary>
        /// Формат.
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// ВысотаЯчейки.
        /// </summary>
        public ushort CellHeight { get; set; }

        /// <summary>
        /// АвтоВысотаЯчейки.
        /// </summary>
        public bool AutoCellHeight { get; set; }

        /// <summary>
        /// Ширина.
        /// </summary>
        public ushort Width { get; set; }

        /// <summary>
        /// Оформление шапки.
        /// </summary>
        public TableBoxColumnDecoration HeaderDecoration { get; set; }

        /// <summary>
        /// Оформление ячейки.
        /// </summary>
        public TableBoxColumnDecoration CellDecoration { get; set; }

        /// <summary>
        /// Оформление подвала.
        /// </summary>
        public TableBoxColumnDecoration FooterDecoration { get; set; }

        public TableBoxColumn()
        {
            DataPath = string.Empty;
            Control = new TextBox();

            CheckBoxDataPath = string.Empty;
            PictureData = string.Empty;

            Enabled = true;
            Visible = true;

            HeaderText = new LocalizedString();
            FooterText = new LocalizedString();

            HeaderToolTip = new LocalizedString();

            VisibleInHeader = true;
            VisibleInFooter = true;

            EditMode = ColumnEditMode.Enter;

            CanChangeVisible = true;
            CanChangeSetting = true;
            CanChangePosition = true;

            Format = string.Empty;

            CellHeight = 1;

            Width = 100;

            HeaderDecoration = new TableBoxColumnDecoration
            {
                HorizontalAlign = HorizontalTextAlignment.Left,
            };

            CellDecoration = new TableBoxColumnDecoration
            {
                HorizontalAlign = HorizontalTextAlignment.Auto,
            };

            FooterDecoration = new TableBoxColumnDecoration
            {
                HorizontalAlign = HorizontalTextAlignment.Left,
            };
        }
    }
}
