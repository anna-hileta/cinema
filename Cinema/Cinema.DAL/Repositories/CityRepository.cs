using Cinema.Core.Abstractions.Repositories;
using Cinema.Core.Entities;

namespace Cinema.DAL.Repositories
{
    public class CityRepository: BaseRepository<City, int>, ICityRepository
    {
        public CityRepository(CinemaContext cinemaContext): base(cinemaContext) { }
    }
}
