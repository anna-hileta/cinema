using Cinema.Core.Entities;
using System.Collections.Generic;

namespace Cinema.Core.Abstractions.Services
{
    public interface ICinemaHallService
    {
        public List<CinemaHall> Get();

        public CinemaHall GetById(int id);

        public CinemaHall Add(CinemaHall cinemaHall);

        public CinemaHall Update(CinemaHall cinemaHall);

        public void Delete(int id);
    }

}
