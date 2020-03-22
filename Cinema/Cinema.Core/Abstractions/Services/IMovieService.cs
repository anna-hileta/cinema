using Cinema.Core.Entities;
using System.Collections.Generic;

namespace Cinema.Core.Abstractions.Services
{
    public interface IMovieService
    {
        public List<Movie> Get();

        public Movie GetById(int id);

        public Movie Add(Movie movie);

        public Movie Update(Movie movie);

        public void Delete(int id);
    }

}
