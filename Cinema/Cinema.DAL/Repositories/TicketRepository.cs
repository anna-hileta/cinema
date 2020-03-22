using Cinema.Core.Abstractions.Repositories;
using Cinema.Core.Entities;

namespace Cinema.DAL.Repositories
{
    public class TicketRepository : BaseRepository<Ticket, int>, ITicketRepository
    {
        public TicketRepository(CinemaContext cinemaContext): base(cinemaContext) { }
    }
}
