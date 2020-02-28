using System;

namespace OFP.ObjectModel.Platform.Types
{
    public class RefQualifier : TypeQualifier
    {
        public override PlatformType Type => PlatformType.Ref;

        public Guid TypeId { get; }

        public RefQualifier(Guid typeId)
        {
            TypeId = typeId;
        }
    }
}
