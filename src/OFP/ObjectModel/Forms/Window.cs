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
        public WindowStateVariant State { get; set; }

        /// <summary>
        /// СоединяемоеОкно.
        /// </summary>
        public bool IsConnectable { get; set; }

        /// <summary>
        /// ПоложениеОкна.
        /// </summary>
        public WindowLocationVariant Position { get; set; }

        /// <summary>
        /// ПоложениеПрикрепленногоОкна.
        /// </summary>
        public WindowDockVariant DockPosition { get; set; }

        /// <summary>
        /// ИзменениеРазмера.
        /// </summary>
        public WindowSizeChange CanChangeSize { get; set; }

        /// <summary>
        /// РазрешитьЗакрытие.
        /// </summary>
        public bool CloseAllowed { get; set; }

        /// <summary>
        /// СпособОтображенияОкна.
        /// </summary>
        public WindowAppearanceModeVariant Appearance { get; set; }

        /// <summary>
        /// ИзменятьСпособОтображенияОкна.
        /// </summary>
        public WindowAppearanceModeChange CanChangeAppearance { get; set; }

        /// <summary>
        /// РежимРабочегоСтола.
        /// </summary>
        public bool DesktopModeEnabled { get; set; }

        public Window()
        {
            State = WindowStateVariant.Normal;
            DockPosition = WindowDockVariant.Left;

            CloseAllowed = true;

            Appearance = WindowAppearanceModeVariant.Normal;
            CanChangeAppearance = WindowAppearanceModeChange.Auto;
        }
    }
}
