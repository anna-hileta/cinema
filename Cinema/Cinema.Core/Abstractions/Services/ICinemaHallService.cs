using Cinema.Core.Entities;
using System.Collections.Generic;

namespace Cinema.Core.Abstractions.Services
{
    public interface ICinemaHallService : IBasicService<CinemaHall, int> {
        public List<CinemaHall> GetWithAll();
    }

}
