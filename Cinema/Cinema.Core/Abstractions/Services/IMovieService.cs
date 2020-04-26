using Cinema.Core.Entities;
using System.Collections.Generic;

namespace Cinema.Core.Abstractions.Services
{
    public interface IMovieService : IBasicService<Movie, int> {
        public List<Movie> GetWithAllInfo();
    }
}
