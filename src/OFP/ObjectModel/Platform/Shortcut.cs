using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.Platform
{
    public struct Shortcut
    {
        public KeyModifier Modifiers { get; }
        public Key Key { get; }

        public Shortcut(Key key, KeyModifier modifiers = KeyModifier.None)
        {
            (Key, Modifiers) = (key, modifiers);
        }
    }
}
