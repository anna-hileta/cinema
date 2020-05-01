using System;
using System.Collections.Generic;
using System.Text;
using MigraDoc.DocumentObjectModel;

namespace Cinema.Services.PDF.Interfaces
{
    internal interface IPDFDocument
    {
        Document GetDocument();
        void SetDocumentBody(Section section);
    }
}
