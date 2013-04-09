using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace JonMoreBugs
{
    [TestFixture]
    public class MultipleEnumeration
    {
        public class FileEnumerable
        {
            private readonly List<string> files;

            public FileEnumerable()
            {
                files = new List<string>()
                    {
                        "file1.cs",
                        "file2.cs",
                        "file3.cs"
                    };
            }

            public IEnumerable<string> GetFiles()
            {
                return files;
            }

            public void FileIsDeletedByDifferentProcess()
            {
                files.RemoveAt(2);
            }
        }

        [Test]
        public void Thing()
        {
            var e = new FileEnumerable();
            var files = e.GetFiles();
            Assert.AreEqual(3, files.Count());

            e.FileIsDeletedByDifferentProcess();

            Assert.AreEqual(3, files.Count());
        }
    }
}