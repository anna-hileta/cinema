using System;
using System.Collections.Generic;

namespace Cinema.Core.Entities
{
    public class Movie: IEntity<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Length { get; set; }
        public DateTime PremiereDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DirectorId { get; set; }
        public Director Director { get; set; }
        public int CountryOfOriginId { get; set; }
        public CountryOfOrigin CountryOfOrigin { get; set; }
        public string Poster { get; set; }
        public List<MovieGenre> MovieGenres { get; set; }
        public List<Showing> Showings { get; set; }
    }
}
