using System.Collections.Generic;

namespace Cinema.Core.Entities
{
    public class CinemaLocation: IEntity<int>
    {
        public int Id { get; set; }
        public string CinemaName { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public List<CinemaHall> CinemaHalls { get; set; }
        public List<FoodAmount> FoodAmounts { get; set; }

    }
}
