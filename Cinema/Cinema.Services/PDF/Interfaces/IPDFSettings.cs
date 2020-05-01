using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Services.PDF.Interfaces
{
    interface IPDFSettings
    {
        string Title { get; set; }
        string Subject { get; set; }
        string Author { get; set; }
        string FontName { get; set; }
        string StyleName { get; set; }
        string ImagePath { get; set; }
    }
}
