using Cinema.Core.Abstractions.Repositories;
using Cinema.Core.Entities;

namespace Cinema.DAL.Repositories
{
    public class CountryOfOriginRepository: BaseRepository<CountryOfOrigin, int>, ICountryOfOriginRepository
    {
        public CountryOfOriginRepository(CinemaContext cinemaContext): base(cinemaContext) { }
    }
}
