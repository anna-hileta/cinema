using Cinema.Core.Abstractions.Services;
using Cinema.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.ViewModels
{
    public class ShowingCreateAndEditViewModel
    {
        public Showing showing { get; set; }
        public List<Tuple<int, string>> cinemaLocations;
        public List<Movie> movies;
    }
}
