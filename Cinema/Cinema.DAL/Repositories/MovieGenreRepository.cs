using Cinema.Core.Abstractions.Repositories;
using Cinema.Core.Entities;

namespace Cinema.DAL.Repositories
{
    public class MovieGenreRepository: BaseRepository<MovieGenre, int>, IMovieGenreRepository
    {
        public MovieGenreRepository(CinemaContext cinemaContext): base(cinemaContext) { }
    }
}
