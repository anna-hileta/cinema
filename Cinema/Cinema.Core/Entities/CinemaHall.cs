using System;
using System.Collections.Generic;

namespace Cinema.Core.Entities
{
    public class CinemaHall: IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RowsCount { get; set; }
        public int SeatsCount { get; set; }
        public List<Showing> Showings { get; set; }
        public int? TechnologyId { get; set; }
        public Technology Technology { get; set; }
        public int? CinemaLocationId { get; set; }
        public CinemaLocation CinemaLocation { get; set; }
    }
}
