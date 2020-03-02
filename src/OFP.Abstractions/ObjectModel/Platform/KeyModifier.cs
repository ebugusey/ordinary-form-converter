using System;

namespace OFP.ObjectModel.Platform
{
    [Flags]
    public enum KeyModifier
    {
        None = 0x0,
        Shift = 0x4,
        Ctrl = 0x8,
        Alt = 0x10,
    }
}
