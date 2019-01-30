using OFP.ObjectModel.Localization;

namespace OFP.ObjectModel.FormElements.Decorative
{
    /// <summary>
    /// РамкаГруппы.
    /// </summary>
    public class GroupBox : Element
    {
        /// <summary>
        /// Заголовок.
        /// </summary>
        public LocalizedString Title { get; set; }

        /// <summary>
        /// Оформление рамки группы.
        /// </summary>
        public GroupBoxDecoration Decor { get; set; }
    }
}
