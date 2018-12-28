using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.Platform
{
    public abstract class Picture
    {
        public abstract PictureType Type { get; }
    }

    public enum PictureType
    {
        Empty = 0,
        FromLib = 1,
        Absolute = 3,
    }
}
