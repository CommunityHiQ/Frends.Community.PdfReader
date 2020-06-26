#pragma warning disable 1591

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Frends.Community.PdfReader
{
     public class Options
    {
        /// <summary>
        /// Read data from a pdf file
        /// </summary>
        public bool ReadFromFile { get; set; }

        /// <summary>
        /// PDF document Directory
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        [DefaultValue(@"C:\Input\file.pdf")]
        [UIHint(nameof(ReadFromFile), "", true)]
        public string PdfLocation { get; set; }

        /// <summary>
        /// Byte Array of the pdf
        /// </summary>
        [DisplayFormat(DataFormatString = "Expression")]
        [UIHint(nameof(ReadFromFile), "", false)]
        public byte[] InputBytes { get; set; }

        /// <summary>
        /// Specify which page to read. 0 to read all
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        [DefaultValue(0)]
        public int Page { get; set; }

    }

    public class Output
    {
        public string Content { get; set; }
    }
}
