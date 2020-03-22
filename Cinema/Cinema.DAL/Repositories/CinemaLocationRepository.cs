using Cinema.Core.Abstractions.Repositories;
using Cinema.Core.Entities;

namespace Cinema.DAL.Repositories
{
    public class CinemaLocationRepository: BaseRepository<CinemaLocation, int>, ICinemaLocationRepository
    {
        public CinemaLocationRepository(CinemaContext cinemaContext): base(cinemaContext) { }
    }
}
