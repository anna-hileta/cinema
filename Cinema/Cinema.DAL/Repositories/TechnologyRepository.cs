using Cinema.Core.Abstractions.Repositories;
using Cinema.Core.Entities;

namespace Cinema.DAL.Repositories
{
    public class TechnologyRepository : BaseRepository<Technology, int>, ITechnologyRepository
    {
        public TechnologyRepository(CinemaContext cinemaContext): base(cinemaContext) { }
    }
}
