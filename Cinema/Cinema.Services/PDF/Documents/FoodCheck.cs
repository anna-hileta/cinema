using Cinema.Services.PDF.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using Cinema.Core.Entities;

namespace Cinema.Services.PDF.Documents
{
    public class FoodCheck : PDFDocument
    {
        private readonly FoodcourtCheck ticket;
        private readonly IPDFSettings settings;
        public FoodCheck(FoodcourtCheck ticket) : this(ticket, new PDFSettings())
        {
        }
        public FoodCheck(FoodcourtCheck ticket, IPDFSettings settings) : base(settings)
        {
            this.ticket = ticket;
            this.settings = settings;
        }
        public override void SetDocumentBody(Section section)
        {
            var paragraph = section.AddParagraph($"Check created on {ticket.TransactionDateAndTime.ToString("dd/MM/yyyy")}");
            paragraph.Format.Font.Size = 14;
            paragraph.Format.SpaceAfter = "3cm";
            paragraph.Format.SpaceBefore = "8cm";
            paragraph.Format.Alignment = ParagraphAlignment.Right;
            
            for(int i = 0; i<ticket.FoodcourtCheckProducts.Count; ++i)
            {
                paragraph = section.AddParagraph($"Food product: {ticket.FoodcourtCheckProducts[i].FoodAmount.FoodProducts.ProductName} with price per one {ticket.FoodcourtCheckProducts[i].FoodAmount.FoodProducts.ProductPrice}");
                paragraph.Format.Font.Size = 12;
                paragraph.Format.SpaceAfter = "1cm";

                paragraph = section.AddParagraph($"Amount of food item: {ticket.FoodcourtCheckProducts[i].AmountOfProduct}");
                paragraph.Format.Font.Size = 12;
                paragraph.Format.SpaceAfter = "1cm";
            }

            paragraph = section.AddParagraph($"Total price: {ticket.PaidPrice}");
            paragraph.Format.Font.Size = 12;
            paragraph.Format.SpaceAfter = "1cm";

            paragraph = section.AddParagraph($"Sold by {ticket.Worker.Name} {ticket.Worker.Surname}");
            paragraph.Format.Font.Size = 14;
            paragraph.Format.SpaceBefore = "5cm";
            paragraph.Format.Alignment = ParagraphAlignment.Right;
    }
    }
}
