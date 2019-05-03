using System.ComponentModel;
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
                using (var reader = new iTextSharp.text.pdf.PdfReader(options.PdfLocation))
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
            else
            {
                using (var reader = new iTextSharp.text.pdf.PdfReader(options.InputBytes))
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
    }
}
