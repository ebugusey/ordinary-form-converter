using System;
using System.Collections.Generic;
using System.Text;
using OFP.ObjectModel.Common;
using OFP.ObjectModel.Platform;
using OFP.ObjectModel.Localization;

namespace OFP.ObjectModel.FormElements.Decorative
{
    /// <summary>
    /// ПолеКартинки.
    /// </summary>
    public class PictureBox : Element
    {
        /// <summary>
        /// Оформление ПолеКартинки.
        /// </summary>
        public PictureBoxDecoration Decoration { get; set; }

        /// <summary>
        /// РазрешитьПеретаскивание.
        /// </summary>
        public bool IsEnableDragAndDrop { get; set; }

        /// <summary>
        /// РазрешитьНачалоПеретаскивания.
        /// </summary>
        public bool IsEnableStartDragAndDrop { get; set; }

        /// <summary>
        /// Гиперссылка.
        /// </summary>
        public bool IsHyperlink { get; set; }

        /// <summary>
        /// ТекстНевыбраннойКартинки.
        /// </summary>
        public LocalizedString NonselectedPictureText { get; set; }

        /// <summary>
        /// ИспользоватьКонтекстноеМеню.
        /// </summary>
        public bool IsEnableContextMenu { get; set; }

        /// <summary>
        /// Масштабировать.
        /// </summary>
        public bool HasScalability { get; set; }

        /// <summary>
        /// СочетаниеКлавиш.
        /// </summary>
        public Shortcut Shortcut { get; set; }

        /// <summary>
        /// События ПолеКартинки.
        /// </summary>
        public Events<PictureBoxEvent> Events { get; set; }
    }
}
