using Cinema.Core.Abstractions.Repositories;
using Cinema.Core.Entities;

namespace Cinema.DAL.Repositories
{
    public class DirectorRepository: BaseRepository<Director, int>, IDirectorRepository
    {
        public DirectorRepository(CinemaContext cinemaContext): base(cinemaContext) { }
    }
}
