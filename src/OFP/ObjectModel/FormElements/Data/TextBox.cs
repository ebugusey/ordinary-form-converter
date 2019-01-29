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
        public bool AutoChoiceIncomplete { get; set; }

        /// <summary>
        /// АвтоОтметкаНезаполненного.
        /// </summary>
        public bool AutoMarkIncomplete { get; set; }

        public bool ChoiceIncomplete { get; set; }
        public bool MarkIncomplete { get; set; }

        /// <summary>
        /// ВыбиратьТип.
        /// </summary>
        public bool ChooseType { get; set; }

        /// <summary>
        /// ВыделятьОтрицательные.
        /// </summary>
        public bool MarkNegatives { get; set; }

        /// <summary>
        /// АктивизироватьПоУмолчанию.
        /// </summary>
        public bool IsDefaultControl { get; set; }

        /// <summary>
        /// МногострочныйРежим.
        /// </summary>
        public bool IsMultiLine { get; set; }

        /// <summary>
        /// РежимПароля.
        /// </summary>
        public bool PasswordMode { get; set; }

        /// <summary>
        /// РасширенноеРедактирование.
        /// </summary>
        public bool ExtendedEdit { get; set; }

        /// <summary>
        /// АвтоПереносСтрок.
        /// </summary>
        public bool Wrap { get; set; }

        /// <summary>
        /// МинимальноеЗначение.
        /// </summary>
        public decimal MinValue { get; set; }

        /// <summary>
        /// МаксимальноеЗначение
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
        public TextBoxDecoration Decor { get; set; }

        /// <summary>
        /// События поля ввода.
        /// </summary>
        public Events<TextBoxEvent> Events { get; set; }
    }
}
