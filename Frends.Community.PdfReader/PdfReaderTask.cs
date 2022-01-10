using System.ComponentModel;
using System.Text;
using System.Threading;
using System.IO;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Kernel.Pdf.Canvas.Parser;

#pragma warning disable 1591

namespace Frends.Community.PdfReader
{
    public class PdfReaderTask
    {
        /// <summary>
        /// Read pdf and return content as string.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Object { string Content }</returns>
        public static Output ReadPdf([PropertyTab] Options options, CancellationToken cancellationToken)
        {
            var text = new StringBuilder();
            using (var reader = options.ReadFromFile ? new iText.Kernel.Pdf.PdfReader(options.PdfLocation) : new iText.Kernel.Pdf.PdfReader(new MemoryStream(options.InputBytes)))
            {
                // For possible form flattening.
                var writer = new PdfWriter(new MemoryStream());
                var doc = new PdfDocument(reader, writer);
                var form = iText.Forms.PdfAcroForm.GetAcroForm(doc, false);
                if (form != null)
                {
                    form.FlattenFields();
                }

                if (options.Page == 0)
                {
                    for (var i = 1; i <= doc.GetNumberOfPages(); i++)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        var strategy = new SimpleTextExtractionStrategy();
                        text.Append(PdfTextExtractor.GetTextFromPage(doc.GetPage(i), strategy));
                    }
                }
                else
                {
                    var strategy = new SimpleTextExtractionStrategy();
                    text.Append(PdfTextExtractor.GetTextFromPage(doc.GetPage(options.Page), strategy));
                }
            }
            return new Output { Content = text.ToString() };
        }
    }
}
