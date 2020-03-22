using System;
using System.Collections.Generic;

namespace Cinema.Core.Entities
{
    public class Showing: IEntity<int>
    {
        public int Id { get; set; }
        public DateTime DateAndTime { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int CinemaHallId { get; set; }
        public CinemaHall CinemaHall { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}
