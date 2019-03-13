using OFP.ObjectModel.Common;

namespace OFP.ObjectModel.FormElements.Decorative
{
    /// <summary>
    /// Разделитель.
    /// </summary>
    public class Splitter : Element
    {
        /// <summary>
        /// Ориентация.
        /// </summary>
        public Orientation Orientation { get; set; }

        /// <summary>
        /// Оформление Разделитель.
        /// </summary>
        public SplitterDecoration Decoration { get; set; }

        public Splitter()
        {
            Orientation = Orientation.Auto;

            Decoration = new SplitterDecoration();
        }
    }
}
