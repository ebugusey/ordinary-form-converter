using System;

namespace libUnpack.Test.ObjectModel
{
    public class V8FileInfo
    {
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModified { get; set; }
        public int Size { get; set; }
        public byte[] Hash { get; set; }
    }
}
