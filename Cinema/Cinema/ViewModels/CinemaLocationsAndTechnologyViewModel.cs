using Cinema.Core.Abstractions.Services;
using Cinema.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.ViewModels
{
    public class CinemaLocationsAndTechnologyViewModel
    {
        public CinemaHall cinemaHall { get; set; }
        public List<CinemaLocation> cinemaLocations;
        public List<Technology> technologies;
    }
}
