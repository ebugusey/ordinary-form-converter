using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using libUnpack.Test.Mock;

namespace libUnpack.Test
{
    [TestFixture]
    public class V8ContainerTest : TestWithData
    {
        [TestCase(V8ContainerMode.Read, false, true, false, "*Seek*")]
        [TestCase(V8ContainerMode.Write, false, false, true, "*Seek*")]
        [TestCase(V8ContainerMode.Read, true, false, false, "*Read*")]
        [TestCase(V8ContainerMode.Write, true, true, false, "*Write*")]
        public void V8Container_Constructor_ThrowsIfOnIncorrectStream(
            V8ContainerMode mode, bool canSeek, bool canRead, bool canWrite, string expectedMessage)
        {
            using (var baseStream = new SparseMemoryStream(canRead, canWrite, canSeek))
            {
                Action ctor = () =>
                {
                    using (new V8Container(baseStream, mode))
                    {

                    }
                };

                ctor.Should()
                    .Throw<ArgumentException>()
                    .WithMessage(expectedMessage);
            }
        }

        [Test]
        public void V8Container_Open_OpensContainer()
        {
            using (var container = V8Container.Open(ReadOnlyContainerPath))
            {
                container.Should().NotBeNull();
                container.Files.Should().NotBeNullOrEmpty();
            }
        }

        [Test]
        public void V8Container_Create_CreatesEmptyContainer()
        {
            var path = GetTempFileName();

            using (var container = V8Container.Create(path))
            {
                container.Should().NotBeNull();
                container.Files.Should().BeEmpty();
            }
        }

        [Test]
        public void V8Container_Files_ContainFiles()
        {
            var container = ReadOnlyContainer();
            var files = container.Files;

            var expectedNames = FileNames;

            files.Should()
                .HaveSameCount(expectedNames)
                .And.NotContainNulls()
                .And.OnlyHaveUniqueItems(f => f.Name)
                .And.Subject
                    .Select(f => f.Name).Should()
                    .Equal(expectedNames);
        }

        [TestCaseSource(nameof(FileNames))]
        public void V8Container_GetFile_ReturnsFile(string filename)
        {
            var container = ReadOnlyContainer();
            var file = container.GetFile(filename);

            file.Should().NotBeNull();
            file.Name.Should().Be(filename);
        }

        [Test]
        public void V8Container_GetFile_ReturnsNullIfFileDoesntExist()
        {
            var container = ReadOnlyContainer();
            var file = container.GetFile("doesn't exist");

            file.Should().BeNull();
        }

        [TestCaseSource(nameof(FileNames))]
        public void V8Container_CreateFile_CreatesFile(string filename)
        {
            var container = NewContainer();

            var file = container.CreateFile(filename);

            file.Should().NotBeNull();
            file.Name.Should().Be(filename);

            container.Files.Should().Contain(file);
        }

        [Test]
        public void V8Container_CreateFile_ThrowsInReadOnlyContainer()
        {
            var container = ReadOnlyContainer();

            container.Invoking(c => c.CreateFile("new file")).Should()
                .Throw<InvalidOperationException>()
                .WithMessage("*режим*чтения*");
        }

        [Test]
        public void V8Container_CreateFile_ThrowsIfFileAlreadyExists()
        {
            var container = NewContainerWithFile();

            var existingFileName = container.Files[0].Name;

            container.Invoking(c => c.CreateFile(existingFileName)).Should()
                .Throw<InvalidOperationException>()
                .WithMessage("*файл*существует*");
        }
    }
}
