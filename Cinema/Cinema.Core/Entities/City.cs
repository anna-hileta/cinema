using System.Collections.Generic;

namespace Cinema.Core.Entities
{
    public class City: IEntity<int>
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public List<CinemaLocation> CinemaLocations { get; set; }
    }
}
