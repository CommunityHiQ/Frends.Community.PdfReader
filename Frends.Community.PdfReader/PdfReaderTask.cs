using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using iTextSharp.text.pdf.parser;

#pragma warning disable 1591

namespace Frends.Community.PdfReader
{
    public class PdfReaderTask
    {
        /// <summary>
        /// Read pdf and return content as string
        /// </summary>
        /// <param name="options"></param>
        /// <returns>Object { string Content }</returns>
        public static Output ReadPdf([PropertyTab] Options options)
        {
            var text = new StringBuilder();
            if (options.ReadFromFile)
            {
                var reader = new iTextSharp.text.pdf.PdfReader(options.PdfLocation);
                if (reader.AcroForm != null) reader = new iTextSharp.text.pdf.PdfReader(FlattenPdfFormToBytes(reader));
                using (reader)
                {                    
                    if (options.Page == 0)
                    {
                        for (var i = 1; i <= reader.NumberOfPages; i++)
                        {
                            text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                        }
                    }
                    else
                    {
                        text.Append(PdfTextExtractor.GetTextFromPage(reader, options.Page));
                    }
                }
            }
            else
            {
                var reader = new iTextSharp.text.pdf.PdfReader(options.InputBytes);
                if (reader.AcroForm != null) reader = new iTextSharp.text.pdf.PdfReader(FlattenPdfFormToBytes(reader));
                using (reader)
                {
                    if (options.Page == 0)
                    {
                        for (var i = 1; i <= reader.NumberOfPages; i++)
                        {
                            text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                        }
                    }
                    else
                    {
                        text.Append(PdfTextExtractor.GetTextFromPage(reader, options.Page));
                    }
                }
            }

            return new Output { Content = text.ToString() };
        }

        private static byte[] FlattenPdfFormToBytes(iTextSharp.text.pdf.PdfReader reader)
        {
            var memStream = new MemoryStream();
            var stamper = new iTextSharp.text.pdf.PdfStamper(reader, memStream) { FormFlattening = true };
            stamper.Close();
            return memStream.ToArray();
        }
    }
}
