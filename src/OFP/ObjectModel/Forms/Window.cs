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
        /// СоединяемоеОкно.
        /// </summary>
        public bool IsConnectableWindow { get; set; }

        /// <summary>
        /// ПоложениеОкна.
        /// </summary>
        public WindowLocationVariant WindowPosition { get; set; }

        /// <summary>
        /// ПоложениеПрикрепленногоОкна.
        /// </summary>
        public WindowDockVariant WindowDockPosition { get; set; }

        /// <summary>
        /// ИзменениеРазмера.
        /// </summary>
        public WindowSizeChange SizeChange { get; set; }

        /// <summary>
        /// РазрешитьЗакрытие.
        /// </summary>
        public bool CloseAllowed { get; set; }

        /// <summary>
        /// СпособОтображенияОкна.
        /// </summary>
        public WindowAppearanceModeVariant WindowAppearance { get; set; }

        /// <summary>
        /// ИзменятьСпособОтображенияОкна.
        /// </summary>
        public WindowAppearanceModeChange CanChangeWindowAppearance { get; set; }

        /// <summary>
        /// РежимРабочегоСтола.
        /// </summary>
        public bool DesktopModeEnabled { get; set; }
    }
}
