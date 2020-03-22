using System.Collections.Generic;

namespace Cinema.Core.Entities
{
    public class Technology: IEntity<int>
    {
        public int Id { get; set; }
        public string TechnologyName { get; set; }
        public List<CinemaHall> CinemaHalls { get; set; }
    }
}
