using Cinema.Core.Abstractions.Repositories;
using Cinema.Core.Entities;

namespace Cinema.DAL.Repositories
{
    public class PositionRepository: BaseRepository<Position, int>, IPositionRepository
    {
        public PositionRepository(CinemaContext cinemaContext): base(cinemaContext) { }
    }
}
