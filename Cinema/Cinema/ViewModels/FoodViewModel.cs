using Cinema.Core.Abstractions.Services;
using Cinema.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.ViewModels
{
    public class FoodViewModel
    {
        public List<CinemaLocation> locations { get; set; }
        public List<string> allCinemas { get; set; }
    }
}
