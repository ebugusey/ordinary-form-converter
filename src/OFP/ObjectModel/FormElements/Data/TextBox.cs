using System.Collections.Generic;
using OFP.ObjectModel.Common;
using OFP.ObjectModel.FormElements.Data.Extensions;

namespace OFP.ObjectModel.FormElements.Data
{
    /// <summary>
    /// ПолеВвода.
    /// </summary>
    public class TextBox : Element
    {
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

        /// <summary>
        /// Расширения поля ввода.
        /// Зависит от типа значения в поле ввода.
        /// </summary>
        public List<ElementExtension> Extensions { get; set; }

        public TextBox()
        {
            IsChooseType = true;
            TextEditEnabled = true;
            IsWrapText = true;

            Buttons = new TextBoxButtons();

            Decoration = new TextBoxDecoration();
            Events = new Events<TextBoxEvent>();

            Extensions = new List<ElementExtension>();
        }
    }
}
