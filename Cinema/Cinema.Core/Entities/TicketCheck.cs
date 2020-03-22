namespace Cinema.Core.Entities
{
    public class TicketCheck: IEntity<int>
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public int CheckId { get; set; }
        public Check Check { get; set; }
    }
}
