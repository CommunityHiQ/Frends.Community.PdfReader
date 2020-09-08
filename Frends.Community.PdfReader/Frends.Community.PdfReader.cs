using System.ComponentModel;
using System.Text;
using System.Threading;
// using iText.Kernel;
// using iTextSharp.text.pdf.parser;

#pragma warning disable 1591

namespace Frends.Community.PdfReader
{
    public class PdfReaderTask
    {
        /// <summary>
        /// Read pdf and return content as string
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Object { string Content }</returns>
        public static Output ReadPdf([PropertyTab] Options options,CancellationToken cancellationToken)
        {
            var text = new StringBuilder();


            using (var reader = options.ReadFromFile ?
                    new iText.Kernel.Pdf.PdfReader(options.PdfLocation)
                    : new iText.Kernel.Pdf.PdfReader(new System.IO.MemoryStream(options.InputBytes)))
            {
                var writer = new iText.Kernel.Pdf.PdfWriter(new System.IO.MemoryStream()); // for possible form flattening
                var doc = new iText.Kernel.Pdf.PdfDocument(reader,writer);
                var form = iText.Forms.PdfAcroForm.GetAcroForm(doc, false);
                if (form!=null)
                {
                    
                    form.FlattenFields();
                    

                }
                
                using (var pdfdoc = doc)
                {
                    if (options.Page == 0)
                    {
                        for (var i = 1; i <= pdfdoc.GetNumberOfPages(); i++)
                        {
                            var strategy = new iText.Kernel.Pdf.Canvas.Parser.Listener.SimpleTextExtractionStrategy();
                            text.Append(iText.Kernel.Pdf.Canvas.Parser.PdfTextExtractor.GetTextFromPage(pdfdoc.GetPage(i), strategy));
                        }
                    }
                    else
                    {
                        var strategy = new iText.Kernel.Pdf.Canvas.Parser.Listener.SimpleTextExtractionStrategy();
                        text.Append(iText.Kernel.Pdf.Canvas.Parser.PdfTextExtractor.GetTextFromPage(pdfdoc.GetPage(options.Page), strategy));
                    }
                }
            }
            return new Output { Content = text.ToString() };
        }
    }
}
