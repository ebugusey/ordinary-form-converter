using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.Platform
{
    public struct Shortcut
    {
        public bool Shift { get; }
        public bool Alt { get; }
        public bool Ctrl { get; }
        public Key Key { get; }

        public Shortcut(Key key, bool shift = false, bool alt = false, bool ctrl = false)
        {
            (Key, Shift, Alt, Ctrl) = (key, shift, alt, ctrl);
        }
    }
}
