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
        public GroupBoxDecoration Decoration { get; set; }

        public GroupBox()
        {
            Title = new LocalizedString();

            Decoration = new GroupBoxDecoration();
        }
    }
}
