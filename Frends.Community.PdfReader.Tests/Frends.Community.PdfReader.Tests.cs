using System;
using NUnit.Framework;

namespace Frends.Community.PdfReader.Tests
{
    [TestFixture]
    public class ReaderTests
    {
        private readonly string _pdfLocation = $@"{AppDomain.CurrentDomain.BaseDirectory}..\..\..\TestFiles";

        [Test]
        public void ReadPdf_ShouldWork()
        {
            var result = PdfReaderTask.ReadPdf(new Options {ReadFromFile = true, PdfLocation = System.IO.Path.Combine(_pdfLocation,"test.pdf"), Page = 1}, new System.Threading.CancellationToken());

            Assert.IsTrue(result.Content.Contains("This is a test pdf"));
        }


        [Test]
        public void ReadPdf_ReadMutilplePages()
        {
            var result = PdfReaderTask.ReadPdf(new Options { ReadFromFile = true, PdfLocation = System.IO.Path.Combine(_pdfLocation, "multipage_test.pdf"), Page = 0 }, new System.Threading.CancellationToken());
            
            Assert.IsTrue(result.Content.Length==23833);
        }

        [Test]
        public void ReadPdf_ReadOnePageOfMutilplePages()
        {
            var result = PdfReaderTask.ReadPdf(new Options { ReadFromFile = true, PdfLocation = System.IO.Path.Combine(_pdfLocation, "multipage_test.pdf"), Page = 12 }, new System.Threading.CancellationToken());

            Assert.IsTrue(result.Content.Contains("Ketasteride"));
        }
    }
}

