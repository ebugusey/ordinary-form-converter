using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;

namespace libUnpack.Test
{
    [TestFixture]
    public class V8FileTest : TestWithData
    {
        [TestCaseSource(nameof(FileNames))]
        public void V8File_Properties_ContainData(string filename)
        {
            var container = ReadOnlyContainer();
            var file = container.GetFile(filename);

            var expectedData = FilesInfo[filename];

            using (var scope = new AssertionScope())
            {
                file.Name.Should().Be(filename);
                file.CreatedAt.Should().Be(expectedData.CreatedAt);
                file.LastModified.Should().Be(expectedData.LastModified);
            }
        }

        [TestCaseSource(nameof(FileNames))]
        public void V8File_Open_OpensStream(string filename)
        {
            var container = ReadOnlyContainer();
            var file = container.GetFile(filename);

            using (var stream = file.Open())
            {
                stream.Should().NotBeNull();
            }
        }
    }
}
