using System;
using NUnit.Framework;

namespace Frends.Community.PdfReader.Tests
{
    [TestFixture]
    public class ReaderTests
    {
        private readonly string _pdfLocation = $@"{AppDomain.CurrentDomain.BaseDirectory}..\..\..\TestFiles\test.pdf";

        [Test]
        public void ReadPdf_ShouldWork()
        {
            var result = PdfReaderTask.ReadPdf(new Options {ReadFromFile = true, PdfLocation = _pdfLocation, Page = 1}, new System.Threading.CancellationToken());

            Assert.IsTrue(result.Content.Contains("This is a test pdf"));
        }
    }
}
