using System.Collections.Generic;
using OFP.ObjectModel.Localization;
using OFP.ObjectModel.Platform;
using OFP.ObjectModel.Platform.Pictures;

namespace OFP.ObjectModel.FormElements
{
    public class CommandBarButton
    {
        public Identifier Name { get; set; }

        public string Action { get; set; }
        public LocalizedString Description { get; set; }
        public LocalizedString Text { get; set; }
        public LocalizedString ToolTip { get; set; }

        public bool Check { get; set; }
        public bool DefaultButton { get; set; }
        public bool Enabled { get; set; }
        public bool ModifiesData { get; set; }

        public Shortcut Shortcut { get; set; }
        public Picture Picture { get; set; }

        public CommandBarButtonOrder ButtonOrder { get; set; }
        public CommandBarButtonType ButtonType { get; set; }
        public CommandBarButtonRepresentation Representation { get; set; }

        public List<CommandBarButton> ChildElements { get; set; }
    }

    public enum CommandBarButtonOrder
    {
        DontOrder = 0,
        Asc = 1,
        Desc = 2
    }

    public enum CommandBarButtonType
    {
        DontOrder = 0,
        Asc = 1,
        Desc = 2
    }

    public enum CommandBarButtonRepresentation
    {
        Auto = 0,
        Text = 1,
        Picture = 2,
        PictureText = 3
    }
}
