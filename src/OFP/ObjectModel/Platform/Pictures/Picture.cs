using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace OFP.ObjectModel.Platform.Pictures
{
    public abstract class Picture
    {
        public abstract PictureType Type { get; }
    }

    public class EmptyPicture : Picture
    {
        public override PictureType Type => PictureType.Empty;
    }

    public class AbsolutePicture : Picture
    {
        public override PictureType Type => PictureType.Absolute;
        public byte[] Value { get; set; }
    }

    public abstract class PictureFromLib : Picture
    {
        public override PictureType Type => PictureType.FromLib;

        public abstract string Name { get; }
    }

    public class StdPicture<T> : PictureFromLib where T : struct
    {
        public override string Name { get; }
        public T Value { get; }

        public StdPicture(string name, T value)
        {
            Name = name;
            Value = value;
        }

        public override string ToString() => $"StdPicture.{Name}";
    }

    public class PictureFromConfiguration : PictureFromLib
    {
        public override string Name { get; }
        public Guid Value { get; set; }
    }
}
