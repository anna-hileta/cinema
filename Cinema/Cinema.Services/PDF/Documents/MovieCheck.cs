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
            paragraph.Format.SpaceAfter = "1.5cm";
            paragraph.Format.SpaceBefore = "8cm";
            paragraph.Format.Alignment = ParagraphAlignment.Right;

            for(int i = 0; i<ticket.TicketChecks.Count; ++i)
            {
                if(i == 0)
                {
                    paragraph = section.AddParagraph($"Movie: {ticket.TicketChecks[i].Ticket.Showing.Movie.Title}");
                    paragraph.Format.Font.Size = 12;
                    paragraph.Format.SpaceAfter = "0.5cm";

                    paragraph = section.AddParagraph($"In a cinema: {ticket.TicketChecks[i].Ticket.Showing.CinemaHall.CinemaLocation.CinemaName}");
                    paragraph.Format.Font.Size = 12;
                    paragraph.Format.SpaceAfter = "0.5cm";

                    paragraph = section.AddParagraph($"In a cinema hall: {ticket.TicketChecks[i].Ticket.Showing.CinemaHall.Name}");
                    paragraph.Format.Font.Size = 12;
                    paragraph.Format.SpaceAfter = "0.5cm";

                    paragraph = section.AddParagraph($"For the showing on the day: {ticket.TicketChecks[i].Ticket.Showing.DateAndTime}");
                    paragraph.Format.Font.Size = 12;
                    paragraph.Format.SpaceAfter = "0.5cm";
                }
                paragraph = section.AddParagraph($"Ticket with seat number {ticket.TicketChecks[i].Ticket.SeatNumber} and row number {ticket.TicketChecks[i].Ticket.RowNumber}");
                paragraph.Format.Font.Size = 12;
                paragraph.Format.SpaceAfter = "0.5cm";

                paragraph = section.AddParagraph($"The price of the ticket: {ticket.TicketChecks[i].Ticket.Price}");
                paragraph.Format.Font.Size = 12;
                paragraph.Format.SpaceAfter = "0.5cm";
            }

            paragraph = section.AddParagraph($"Total price: {ticket.PaidPrice}");
            paragraph.Format.Font.Size = 12;
            paragraph.Format.SpaceAfter = "0.5cm";

            paragraph = section.AddParagraph($"Sold by {ticket.Worker.Name} {ticket.Worker.Surname}");
            paragraph.Format.Font.Size = 14;
            paragraph.Format.Alignment = ParagraphAlignment.Right;
    }
    }
}
