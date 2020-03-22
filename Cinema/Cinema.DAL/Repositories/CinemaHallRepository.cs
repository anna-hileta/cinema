using Cinema.Core.Abstractions.Repositories;
using Cinema.Core.Entities;

namespace Cinema.DAL.Repositories
{
    public class CinemaHallRepository: BaseRepository<CinemaHall, int>, ICinemaHallRepository
    {
        public CinemaHallRepository(CinemaContext cinemaContext): base(cinemaContext) { }
    }
}
