using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.Forms
{
    /// <summary>
    /// Свойства окна формы.
    /// </summary>
    public class Window
    {
        /// <summary>
        /// СостояниеОкна.
        /// </summary>
        public WindowStateVariant WindowState { get; set; }

        /// <summary>
        /// РазрешитьЗакрытие.
        /// </summary>
        public bool AllowClose { get; set; }

        /// <summary>
        /// РежимРабочегоСтола.
        /// </summary>
        public bool DesktopMode { get; set; }

        /// <summary>
        /// ИзменениеРазмера.
        /// </summary>
        public WindowSizeChange SizeChange { get; set; }

        /// <summary>
        /// СоединяемоеОкно.
        /// </summary>
        public bool ConnectableWindow { get; set; }

        /// <summary>
        /// ПоложениеОкна.
        /// </summary>
        public WindowLocationVariant WindowLocation { get; set; }

        /// <summary>
        /// ПоложениеПрикрепленногоОкна.
        /// </summary>
        public WindowDockVariant WindowDockLocation { get; set; }

        /// <summary>
        /// СпособОтображенияОкна.
        /// </summary>
        public WindowAppearanceModeVariant WindowAppearanceMode { get; set; }

        /// <summary>
        /// ИзменятьСпособОтображенияОкна.
        /// </summary>
        public WindowAppearanceModeChange ChangeWindowAppearanceMode { get; set; }
    }
}
