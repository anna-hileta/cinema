using Cinema.Core.Abstractions.Services;
using Cinema.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.ViewModels
{
    public class EditMovieViewModel
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string CountryOfOrigin { get; set; }
        public string DirectorName { get; set; }
        public DateTime PremiereDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime Length { get; set; }
        public string Poster { get; set; }
        public string Description { get; set; }
        public List<Genre> genre { get; set; }
    }
}
