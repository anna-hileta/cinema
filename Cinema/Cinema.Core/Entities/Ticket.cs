using System.Collections.Generic;

namespace Cinema.Core.Entities
{
    public class Ticket: IEntity<int>
    {
        public int Id { get; set; }
        public int ShowingId { get; set; }
        public Showing Showing { get; set; }
        public int RowNumber { get; set; }
        public int SeatNumber { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; }
        public List<TicketCheck> TicketChecks { get; set; }
    }
}
