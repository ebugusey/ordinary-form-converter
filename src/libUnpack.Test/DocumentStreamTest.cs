using System;
using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using libUnpack.IO;

namespace libUnpack.Test
{
    [TestFixture]
    public class DocumentStreamTest : TestWithData
    {
        private byte[] ThreeBytes => new byte[] { 1, 2, 3 };

        [Test]
        public void DocumentStream_IsReadOnlyInReadOnlyContainer()
        {
            var container = ReadOnlyContainer();
            var file = container.Files[0];

            using (var stream = file.Open())
            {
                (stream.CanRead && !stream.CanWrite).Should().BeTrue();
            }
        }

        [Test]
        public void DocumentStream_IsWritableInNewContainer()
        {
            var container = NewContainerWithFile();
            var file = container.Files[0];

            using (var stream = file.Open())
            {
                stream.CanWrite.Should().BeTrue();
            }
        }

        [TestCaseSource(nameof(FileNames))]
        public void DocumentStream_ContainsCorrectData(string filename)
        {
            var container = ReadOnlyContainer();
            var file = container.GetFile(filename);

            var expectedData = FilesInfo[filename];

            using (var stream = file.Open())
            using (var scope = new AssertionScope())
            {
                var hash = Hash.ComputeHash(stream);

                stream.Length.Should().Be(expectedData.Size);
                hash.Should().Equal(expectedData.Hash);
            }
        }

        [TestCaseSource(nameof(RandomData), new object[] { 4, 4096, 4096*4 })]
        public void DocumentStream_Write_WritesDataCorrectly(byte[] data)
        {
            var path = GetTempFileName();

            const string filename = "new file";

            using (var writable = V8Container.Create(path))
            {
                var file = writable.CreateFile(filename);

                using (var stream = file.Open())
                using (var scope = new AssertionScope())
                {
                    stream.Write(data.AsSpan());

                    stream.Length.Should().Be(data.Length);
                    stream.Position.Should().Be(data.Length);
                }
            }

            using (var readable = V8Container.Open(path))
            {
                var file = readable.GetFile(filename);
                var expectedHash = Hash.ComputeHash(data);

                using (var stream = file.Open())
                using (var scope = new AssertionScope())
                {
                    var hash = Hash.ComputeHash(stream);

                    stream.Length.Should().Be(data.Length);
                    hash.Should().Equal(expectedHash);
                }
            }
        }

        [Test]
        public void DocumentStream_IsLimitedByMaxLength()
        {
            var container = NewContainer();

            using (var stream = container.CreateDocument().Open())
            using (var scope = new AssertionScope())
            {
                var data = ThreeBytes;

                stream.Invoking(s =>
                {
                    s.SetLength(DocumentStream.MaxLength);
                    s.Seek(DocumentStream.MaxLength, SeekOrigin.Begin);

                    s.Seek(-data.Length, SeekOrigin.End);
                    s.Write(data.AsSpan());
                })
                .Should().NotThrow<IOException>();

                const string expectedMessage = "*максимальный*размер*";

                stream.Invoking(s => s.SetLength(DocumentStream.MaxLength + 1)).Should()
                    .Throw<IOException>()
                    .WithMessage(expectedMessage);

                stream.Invoking(s => s.Seek(1, SeekOrigin.End)).Should()
                    .Throw<IOException>()
                    .WithMessage(expectedMessage);

                stream.Position = DocumentStream.MaxLength;
                stream.Invoking(s => s.Write(data.AsSpan())).Should()
                    .Throw<IOException>()
                    .WithMessage(expectedMessage);
            }
        }

        [Test]
        public void DocumentStream_Position_CanBeMoreThanLength()
        {
            var containers = new List<V8Container>
            {
                ReadOnlyContainer(),
                NewContainerWithFile()
            };

            foreach (var container in containers)
            {
                test(container);
            }

            void test(V8Container container)
            {
                var file = container.Files[0];

                using (var stream = file.Open())
                using (var scope = new AssertionScope())
                {
                    var expectedLength = stream.Length;
                    var expectedPosition = expectedLength + 1;

                    stream.Position = stream.Length + 1;

                    stream.Position.Should().Be(expectedPosition);
                    stream.Length.Should().Be(expectedLength, "длина не должна изменится");
                }
            }
        }

        [Test]
        public void DocumentStream_Read_ReadsZeroBytesWhenPositionIsMoreThanLength()
        {
            var container = ReadOnlyContainer();
            var file = container.Files[0];

            using (var stream = file.Open())
            {
                stream.Position = stream.Length + 50;
                var data = ThreeBytes;

                var bytesRead = stream.Read(data.AsSpan());

                bytesRead.Should().Be(0);
            }
        }

        [Test]
        public void DocumentStream_Write_ExpandsStreamWhenPositionIsMoreThanLength()
        {
            var container = NewContainerWithFile();
            var file = container.Files[0];

            using (var stream = file.Open())
            using (var scope = new AssertionScope())
            {
                stream.Position = stream.Length + 50;
                var data = ThreeBytes;

                var expectedLength = stream.Position + data.Length;

                stream.Write(data.AsSpan());

                stream.Length.Should().Be(expectedLength);
            }
        }
    }
}
