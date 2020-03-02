using System;

namespace OFP.ObjectModel.Common
{
    public readonly struct Point : IEquatable<Point>
    {
        public ushort X { get; }
        public ushort Y { get; }

        public Point(ushort x, ushort y)
        {
            (X, Y) = (x, y);
        }

        #region Object

        public override string ToString() => $"{X}:{Y}";

        public override int GetHashCode() => X ^ Y;

        public override bool Equals(object obj)
        {
            bool result;
            switch (obj)
            {
                case Point point:
                    result = Equals(in point);
                    break;
                default:
                    result = false;
                    break;
            }

            return result;
        }

        #endregion

        #region IEquatable

        public bool Equals(Point other) => Equals(in other);

        #endregion

        private bool Equals(in Point other) =>
            X == other.X &&
            Y == other.Y;

        public static bool operator ==(Point left, Point right) =>
            left.Equals(in right);
        public static bool operator !=(Point left, Point right) =>
            !left.Equals(in right);
    }
}
