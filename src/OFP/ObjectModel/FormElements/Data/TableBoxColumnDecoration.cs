using OFP.ObjectModel.Platform;
using OFP.ObjectModel.Platform.Borders;
using OFP.ObjectModel.Platform.Colors;
using OFP.ObjectModel.Platform.Fonts;
using OFP.ObjectModel.Platform.Pictures;
using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.FormElements.Data
{
    /// <summary>
    /// Оформление колонки табличного поля.
    /// </summary>
    public class TableBoxColumnDecoration
    {
        //FIXME: Надо удалить свойство.
        public Border Border { get; set; }
        //FIXME: Надо удалить свойство.
        public Font Font { get; set; }

        /// <summary>
        /// Ширина.
        /// </summary>
        public ushort Width { get; set; }

        /// <summary>
        /// ЦветФонаПоля.
        /// </summary>
        public Color FieldBackgroundColor { get; set; }

        /// <summary>
        /// ЦветТекстаПоля.
        /// </summary>
        public Color FieldTextColor { get; set; }

        /// <summary>
        /// ЦветФонаШапки.
        /// </summary>
        public Color HeaderBackgroundColor { get; set; }

        /// <summary>
        /// ЦветТекстаШапки
        /// </summary>
        public Color HeaderTextColor { get; set; }

        //FIXME: Изменить описание на ЦветФонаПодвала.
        /// <summary>
        /// ЦветТекстаПодвала.
        /// </summary>
        public Color FooterBackgroundColor { get; set; }

        /// <summary>
        /// ЦветТекстаПодвала.
        /// </summary>
        public Color FooterTextColor { get; set; }

        //FIXME: Надо удалить свойство.
        public Picture HeaderAdditionalPicture { get; set; }

        /// <summary>
        /// ШрифтТекста.
        /// </summary>
        public Font TextFont { get; set; }

        /// <summary>
        /// ШрифтШапки.
        /// </summary>
        public Font HeaderTextFont { get; set; }

        /// <summary>
        /// ШрифтПодвала.
        /// </summary>
        public Font FooterTextFont { get; set; }

        /// <summary>
        /// КартинкаШапки.
        /// </summary>
        public Picture HeaderPicture { get; set; }

        /// <summary>
        /// КартинкиСтрок.
        /// </summary>
        public Picture RowsPictures { get; set; }

        /// <summary>
        /// КартинкаПодвала.
        /// </summary>
        public Picture FooterPicture { get; set; }

        /// <summary>
        /// ГоризонтальноеПоложениеВШапке.
        /// </summary>
        public HorizontalTextAlignment HeaderHorizontalAlign { get; set; }

        /// <summary>
        /// ГоризонтальноеПоложениеВКолонке.
        /// </summary>
        public HorizontalTextAlignment ColumnHorizontalAlign { get; set; }

        /// <summary>
        /// ГоризонтальноеПоложениеВПодвале.
        /// </summary>
        public HorizontalTextAlignment FooterHorizontalAlign { get; set; }

        public TableBoxColumnDecoration()
        {
            Width = 100;

            FieldBackgroundColor = new AutoColor();
            FieldTextColor = new AutoColor();

            HeaderBackgroundColor = new AutoColor();
            HeaderTextColor = new AutoColor();

            FooterBackgroundColor = new AutoColor();
            FooterTextColor = new AutoColor();

            TextFont = new AutoFont();
            HeaderTextFont = new AutoFont();
            FooterTextFont = new AutoFont();

            HeaderPicture = new EmptyPicture();
            RowsPictures = new EmptyPicture();
            FooterPicture = new EmptyPicture();


            HeaderHorizontalAlign = HorizontalTextAlignment.Left;
            ColumnHorizontalAlign = HorizontalTextAlignment.Auto;
            FooterHorizontalAlign = HorizontalTextAlignment.Left;
        }
    }
}
