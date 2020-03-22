using Cinema.Core.Entities;
using System.Collections.Generic;

namespace Cinema.Core.Abstractions.Services
{
    public interface IGenreService
    {
        public List<Genre> Get();

        public Genre GetById(int id);

        public Genre Add(Genre genre);

        public Genre Update(Genre genre);

        public void Delete(int id);
    }

}
