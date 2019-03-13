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
        public bool AutoBindingsEnabled { get; set; }

        /// <summary>
        /// АвтоПорядокОбхода.
        /// </summary>
        public bool AutoTabOrderEnabled { get; set; }

        /// <summary>
        /// РежимПрокручиваемыхСтраниц.
        /// </summary>
        public bool ScrollPageModeEnabled { get; set; }

        /// <summary>
        /// ОтображениеЗакладок.
        /// </summary>
        public ShowTabs TabsStyle { get; set; }

        /// <summary>
        /// Оформление панели.
        /// </summary>
        public PanelDecoration Decoration { get; set; }

        /// <summary>
        /// Страницы.
        /// </summary>
        public List<PanelPage> Pages { get; }

        /// <summary>
        /// События панели.
        /// </summary>
        public Events<PanelEvent> Events { get; }

        public Panel()
        {
            AutoBindingsEnabled = true;
            AutoTabOrderEnabled = true;

            TabsStyle = ShowTabs.Top;

            Decoration = new PanelDecoration();
            Events = new Events<PanelEvent>();

            Pages = new List<PanelPage>();
        }
    }
}
