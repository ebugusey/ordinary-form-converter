using OFP.ObjectModel.Platform;
using OFP.ObjectModel.Platform.Pictures;
using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.Forms
{
    /// <summary>
    /// Оформление формы.
    /// </summary>
    public class FormDecoration
    {
        /// <summary>
        /// Стиль.
        /// </summary>
        public string Style { get; set; }

        /// <summary>
        /// КартинкаЗаголовка.
        /// </summary>
        public Picture CaptionPicture { get; set; }
    }
}
