using OFP.ObjectModel.Common;

namespace OFP.ObjectModel.FormElements.Data
{
    /// <summary>
    /// ПолеВвода.
    /// </summary>
    public class TextBox : Element
    {
        /// <summary>
        /// АвтоВыборНезаполненного.
        /// </summary>
        public bool AutoChoiceBlank { get; set; }

        /// <summary>
        /// АвтоОтметкаНезаполненного.
        /// </summary>
        public bool AutoMarkBlank { get; set; }

        public bool ChoiceIncomplete { get; set; }
        public bool MarkIncomplete { get; set; }

        /// <summary>
        /// ВыбиратьТип.
        /// </summary>
        public bool IsChooseType { get; set; }

        /// <summary>
        /// ВыделятьОтрицательные.
        /// </summary>
        public bool IsMarkNegativeNumbers { get; set; }

        /// <summary>
        /// АктивизироватьПоУмолчанию.
        /// </summary>
        public bool ActivetedByDefault { get; set; }

        /// <summary>
        /// МногострочныйРежим.
        /// </summary>
        public bool InMultiLineMode { get; set; }

        /// <summary>
        /// РежимПароля.
        /// </summary>
        public bool InPasswordMode { get; set; }

        /// <summary>
        /// РасширенноеРедактирование.
        /// </summary>
        public bool IsExtendedEdit { get; set; }

        /// <summary>
        /// АвтоПереносСтрок.
        /// </summary>
        public bool IsWrapText { get; set; }

        /// <summary>
        /// МинимальноеЗначение.
        /// </summary>
        public decimal MinValue { get; set; }

        /// <summary>
        /// МаксимальноеЗначение.
        /// </summary>
        public decimal MaxValue { get; set; }

        /// <summary>
        /// Маска.
        /// </summary>
        public string Mask { get; set; }

        /// <summary>
        /// ГоризонтальноеПоложение.
        /// </summary>
        public HorizontalAlign HorizontalAlign { get; set; }

        /// <summary>
        /// ВертикальноеПоложение.
        /// </summary>
        public VerticalAlign VerticalAlign { get; set; }

        /// <summary>
        /// Оформление поля ввода.
        /// </summary>
        public TextBoxDecoration Decoration { get; set; }

        /// <summary>
        /// События поля ввода.
        /// </summary>
        public Events<TextBoxEvent> Events { get; set; }
    }
}
