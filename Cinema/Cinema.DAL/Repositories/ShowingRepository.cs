using Cinema.Core.Abstractions.Repositories;
using Cinema.Core.Entities;

namespace Cinema.DAL.Repositories
{
    public class ShowingRepository : BaseRepository<Showing, int>, IShowingRepository
    {
        public ShowingRepository(CinemaContext cinemaContext): base(cinemaContext) { }
    }
}
