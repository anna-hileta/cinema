using Cinema.Core.Entities;
using System.Collections.Generic;

namespace Cinema.Core.Abstractions.Services
{
    public interface IMovieGenreService
    {
        public List<MovieGenre> Get();

        public MovieGenre GetById(int id);

        public MovieGenre Add(MovieGenre movieGenre);

        public MovieGenre Update(MovieGenre movieGenre);

        public void Delete(int id);
    }

}
