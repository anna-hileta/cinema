using Cinema.Core.Abstractions.Repositories;
using Cinema.Core.Entities;

namespace Cinema.DAL.Repositories
{
    public class CheckRepository: BaseRepository<Check, int>, ICheckRepository
    {
        public CheckRepository(CinemaContext cinemaContext): base(cinemaContext) { }
    }
}
