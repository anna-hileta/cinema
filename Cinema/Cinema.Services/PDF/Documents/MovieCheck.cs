using Cinema.Services.PDF.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using Cinema.Core.Entities;

namespace Cinema.Services.PDF.Documents
{
    public class MovieCheck : PDFDocument
    {
        private readonly Check ticket;
        private readonly IPDFSettings settings;
        public MovieCheck(Check ticket) : this(ticket, new PDFSettings())
        {
        }
        public MovieCheck(Check ticket, IPDFSettings settings) : base(settings)
        {
            this.ticket = ticket;
            this.settings = settings;
        }
        public override void SetDocumentBody(Section section)
        {
            var paragraph = section.AddParagraph($"Check created on {ticket.TransactionDateAndTime.ToString("dd/MM/yyyy")}");
            paragraph.Format.Font.Size = 14;
            paragraph.Format.SpaceAfter = "3cm";
            paragraph.Format.SpaceBefore = "5cm";
            paragraph.Format.Alignment = ParagraphAlignment.Right;

            paragraph = section.AddParagraph($"Some info");
            paragraph.Format.Font.Size = 12;
            paragraph.Format.SpaceAfter = "1cm";

            paragraph = section.AddParagraph($"Продав");
            paragraph.Format.Font.Size = 14;
            paragraph.Format.SpaceBefore = "5cm";
            paragraph.Format.Alignment = ParagraphAlignment.Right;
    }
    }
}
