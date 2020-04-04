using Cinema.Core.Abstractions.Services;
using Cinema.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.ViewModels
{
    public class CityViewModel
    {
        private readonly ICityService service;
        public readonly List<City> cinemaLocations;

        public CityViewModel(ICityService service) {
            this.service = service;
            cinemaLocations = service.GetWithLocations();
        }
    }
}
