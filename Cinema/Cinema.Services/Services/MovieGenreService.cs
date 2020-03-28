using AutoMapper;
using Cinema.Core.Abstractions;
using Cinema.Core.Abstractions.Services;
using Cinema.Core.Entities;

namespace Cinema.Services.Services
{
    public class MovieGenreService : BaseService<MovieGenre, int>, IMovieGenreService
    {
        public MovieGenreService(IUnitOfWork unitOfWork, IMapper mapper) :
            base(unitOfWork, unitOfWork.MovieGenres, mapper)
        { }
    }
}
