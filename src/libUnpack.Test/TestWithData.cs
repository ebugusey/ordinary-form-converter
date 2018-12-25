using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using NUnit.Framework;
using libUnpack.Test.ObjectModel;
using libUnpack.Test.Mock;

namespace libUnpack.Test
{
    public abstract class TestWithData
    {
        protected static readonly Dictionary<string, V8FileInfo> FilesInfo;
        protected static readonly string[] FileNames;

        protected static readonly string ReadOnlyContainerPath = @"assets/correct.epf";

        protected HashAlgorithm Hash { get; private set; }

        private readonly List<string> _tempFiles = new List<string>();
        private readonly List<IDisposable> _disposables = new List<IDisposable>();

        static TestWithData()
        {
            var time = new DateTime(2018, 12, 18, 17, 23, 55);

            var files = new List<V8FileInfo>()
            {
                new V8FileInfo {
                    Name = "b6f3eb9f-fec4-45db-a108-a8b39f9853c7",
                    CreatedAt = time,
                    LastModified = time,
                    Size = 342,
                    Hash = HexToByteArray("b5834fe843687c8f54f4c2b27feff14c"),
                },
                new V8FileInfo {
                    Name = "copyinfo",
                    CreatedAt = time,
                    LastModified = time,
                    Size = 21,
                    Hash = HexToByteArray("8fad96ef8efce182daa2fec0cb60a829"),
                },
                new V8FileInfo {
                    Name = "root",
                    CreatedAt = time,
                    LastModified = time,
                    Size = 46,
                    Hash = HexToByteArray("9f86e5ff754e7df09a2b66cd10294b0d"),
                },
                new V8FileInfo {
                    Name = "version",
                    CreatedAt = time,
                    LastModified = time,
                    Size = 23,
                    Hash = HexToByteArray("8ef8340badfabd8f7a7bac10421e6dbe"),
                },
                new V8FileInfo {
                    Name = "versions",
                    CreatedAt = time,
                    LastModified = time,
                    Size = 214,
                    Hash = HexToByteArray("ffe614397c57304f2c0a21c4ea45d3d6"),
                },
            };

            FilesInfo = files.ToDictionary(file => file.Name);
            FileNames = FilesInfo.Keys.ToArray();
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Hash = MD5.Create();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Hash.Dispose();
        }

        [TearDown]
        public void TearDown()
        {
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }

            _disposables.Clear();

            foreach (var filename in _tempFiles)
            {
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
            }

            _tempFiles.Clear();
        }

        protected static IEnumerable<byte[]> RandomData(int count, int minSize, int maxSize)
        {
            Debug.Assert(count > 0);
            Debug.Assert(minSize > 0);
            Debug.Assert(maxSize >= minSize);

            var random = TestContext.CurrentContext.Random;

            for (int i = 0; i < count; i++)
            {
                var size = random.Next(minSize, maxSize);
                var data = new byte[size];
                random.NextBytes(data);

                yield return data;
            }
        }

        protected V8Container ReadOnlyContainer()
        {
            var container = V8Container.Open(ReadOnlyContainerPath);
            _disposables.Add(container);

            return container;
        }

        protected V8Container NewContainer()
        {
            var baseStream = SparseMemoryStream.WritableStream();
            var container = new V8Container(baseStream, V8ContainerMode.Write);

            _disposables.Add(container);

            return container;
        }

        protected V8Container NewContainerWithFile()
        {
            var container = NewContainer();
            container.CreateFile("new file");

            return container;
        }

        protected string GetTempFileName()
        {
            var filename = Path.GetTempFileName();
            _tempFiles.Add(filename);

            return filename;
        }

        private static byte[] HexToByteArray(string hex)
        {
            Debug.Assert(!string.IsNullOrEmpty(hex));
            Debug.Assert(hex.Length % 2 == 0);

            var bytes =
                from evenPos in Enumerable.Range(0, hex.Length)
                where evenPos % 2 == 0
                select Convert.ToByte(hex.Substring(evenPos, 2), 16);

            return bytes.ToArray();
        }
    }
}
