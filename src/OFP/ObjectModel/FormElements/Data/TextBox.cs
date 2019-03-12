using OFP.ObjectModel.Common;

namespace OFP.ObjectModel.FormElements.Data
{
    //FIXME: Нет свойств: ФиксДробнаяЧасть, РедактированиеТекста, РежимВыбораНезаполненного, РежимВыбораИзСписка.
    /// <summary>
    /// ПолеВвода.
    /// </summary>
    public class TextBox : Element
    {
        //FIXME: Надо удалить свойство.
        public bool ChoiceIncomplete { get; set; }
        //FIXME: Надо удалить свойство.
        public bool MarkIncomplete { get; set; }

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
        /// ВыбиратьТип.
        /// </summary>
        public bool IsChooseType { get; set; }

        /// <summary>
        /// АвтоПереносСтрок.
        /// </summary>
        public bool IsWrapText { get; set; }

        /// <summary>
        /// ВыделятьОтрицательные.
        /// </summary>
        public bool IsMarkNegativeNumbers { get; set; }

        /// <summary>
        /// Оформление поля ввода.
        /// </summary>
        public TextBoxDecoration Decoration { get; set; }

        /// <summary>
        /// АктивизироватьПоУмолчанию.
        /// </summary>
        public bool ActivetedByDefault { get; set; }

        /// <summary>
        /// События поля ввода.
        /// </summary>
        public Events<TextBoxEvent> Events { get; set; }
    }
}
