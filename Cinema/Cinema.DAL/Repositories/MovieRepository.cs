using Cinema.Core.Abstractions.Repositories;
using Cinema.Core.Entities;

namespace Cinema.DAL.Repositories
{
    public class MovieRepository : BaseRepository<Movie, int>, IMovieRepository
    {
        public MovieRepository(CinemaContext cinemaContext): base(cinemaContext) { }
    }
}
