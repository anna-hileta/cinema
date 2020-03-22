using Cinema.Core.Abstractions.Repositories;
using Cinema.Core.Entities;

namespace Cinema.DAL.Repositories
{
    public class TicketCheckRepository : BaseRepository<TicketCheck, int>, ITicketCheckRepository
    {
        public TicketCheckRepository(CinemaContext cinemaContext): base(cinemaContext) { }
    }
}
