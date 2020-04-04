using Cinema.Core.Entities;
using System.Collections.Generic;

namespace Cinema.Core.Abstractions.Services
{
    public interface ICinemaLocationService : IBasicService<CinemaLocation, int> {
        List<CinemaLocation> GetWithCities();
    }
}
