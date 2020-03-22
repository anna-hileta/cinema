using Cinema.Core.Abstractions.Repositories;
using Cinema.Core.Entities;

namespace Cinema.DAL.Repositories
{
    public class GenreRepository: BaseRepository<Genre, int>, IGenreRepository
    {
        public GenreRepository(CinemaContext cinemaContext): base(cinemaContext) { }
    }
}
