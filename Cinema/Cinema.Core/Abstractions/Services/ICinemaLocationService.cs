using Cinema.Core.Entities;
using System.Collections.Generic;

namespace Cinema.Core.Abstractions.Services
{
    public interface ICinemaLocationService
    {
        public List<CinemaLocation> Get();

        public CinemaLocation GetById(int id);

        public CinemaLocation Add(CinemaLocation cinemaLocation);

        public CinemaLocation Update(CinemaLocation cinemaLocation);

        public void Delete(int id);
    }

}
