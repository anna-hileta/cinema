using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Services.PDF
{
    public class PDFSettings : Interfaces.IPDFSettings
    {
        public string Title { get; set; }
        public string Subject { get; set; }
        public string Author { get; set; }
        public string FontName { get; set; }
        public string StyleName { get; set; }
        public string ImagePath { get; set; }

        public PDFSettings()
        {
            Title = "Check";
            Subject = "Auto generated pdf file";
            Author = "Cinema";
            FontName = "Times New Roman";
            StyleName = "Normal";
            ImagePath = "https://cdn.pixabay.com/photo/2017/11/24/10/43/admission-2974645_960_720.jpg";
        }
    }
}
