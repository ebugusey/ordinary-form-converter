using OFP.ObjectModel.Common;

namespace OFP.ObjectModel.FormElements.Data
{
    /// <summary>
    /// ПолеВвода.
    /// </summary>
    public class TextBox : Element
    {
        /// <summary>
        /// МногострочныйРежим.
        /// </summary>
        public bool InMultiLineMode { get; set; }

        /// <summary>
        /// Маска.
        /// </summary>
        public string Mask { get; set; }

        /// <summary>
        /// РежимПароля.
        /// </summary>
        public bool InPasswordMode { get; set; }

        /// <summary>
        /// РасширенноеРедактирование.
        /// </summary>
        public bool IsExtendedEdit { get; set; }

        /// <summary>
        /// МинимальноеЗначение.
        /// </summary>
        public decimal MinValue { get; set; }

        /// <summary>
        /// МаксимальноеЗначение.
        /// </summary>
        public decimal MaxValue { get; set; }

        /// <summary>
        /// АвтоОтметкаНезаполненного.
        /// </summary>
        public bool AutoMarkBlank { get; set; }

        /// <summary>
        /// АвтоВыборНезаполненного.
        /// </summary>
        public bool AutoChoiceBlank { get; set; }

        /// <summary>
        /// РежимВыбораИзСписка.
        /// </summary>
        public bool InListChoiceMode { get; set; }

        /// <summary>
        /// ВыбиратьТип.
        /// </summary>
        public bool IsChooseType { get; set; }

        /// <summary>
        /// РежимВыбораНезаполненного.
        /// </summary>
        public IncompleteChoiceMode AutoChoiceMode { get; set; }

        /// <summary>
        /// РедактированиеТекста.
        /// </summary>
        public bool TextEditEnabled { get; set; }

        /// <summary>
        /// АвтоПереносСтрок.
        /// </summary>
        public bool IsWrapText { get; set; }

        /// <summary>
        /// ВыделятьОтрицательные.
        /// </summary>
        public bool IsMarkNegativeNumbers { get; set; }

        /// <summary>
        /// ФиксДробнаяЧасть.
        /// </summary>
        public bool FixedFractionPoint { get; set; }

        /// <summary>
        /// Кнопки поля ввода.
        /// </summary>
        public TextBoxButtons Buttons { get; set; }

        /// <summary>
        /// Оформление поля ввода.
        /// </summary>
        public TextBoxDecoration Decoration { get; set; }

        /// <summary>
        /// АктивизироватьПоУмолчанию.
        /// </summary>
        public bool ActivatedByDefault { get; set; }

        /// <summary>
        /// События поля ввода.
        /// </summary>
        public Events<TextBoxEvent> Events { get; set; }

        public TextBox()
        {
            Mask = string.Empty;

            IsChooseType = true;
            TextEditEnabled = true;
            IsWrapText = true;

            Buttons = new TextBoxButtons();

            Decoration = new TextBoxDecoration();
            Events = new Events<TextBoxEvent>();
        }
    }
}
