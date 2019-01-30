using System;
using System.Collections.Generic;
using System.Text;
using OFP.ObjectModel.Common;

namespace OFP.ObjectModel.FormElements.Panels
{
    /// <summary>
    /// Панель.
    /// </summary>
    public class Panel : Element
    {
        /// <summary>
        /// АвтоПравила.
        /// </summary>
        public bool AutoBindings { get; set; }

        /// <summary>
        /// АвтоПорядокОбхода.
        /// </summary>
        public bool AutoTabOrder { get; set; }

        /// <summary>
        /// Оформление панели.
        /// </summary>
        public PanelDecoration Decor { get; set; }

        /// <summary>
        /// События панели.
        /// </summary>
        public Events<PanelEvent> Events { get; }

        /// <summary>
        /// ОтображениеЗакладок.
        /// </summary>
        public ShowTabs TabsStyle { get; set; }

        /// <summary>
        /// РежимПрокручиваемыхСтраниц.
        /// </summary>
        public bool ScrollPageModeEnabled { get; set; }

        /// <summary>
        /// Страницы.
        /// </summary>
        public List<PanelPage> Pages { get; }
    }
}
