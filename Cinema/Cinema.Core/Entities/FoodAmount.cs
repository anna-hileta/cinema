using System.Collections.Generic;

namespace Cinema.Core.Entities
{
    public class FoodAmount: IEntity<int>
    {
        public int Id { get; set; }
        public int CinemaLocationId { get; set; }
        public CinemaLocation CinemaLocation { get; set; }
        public int FoodProductsId { get; set; }
        public FoodProducts FoodProducts { get; set; }
        public int ProductAmount { get; set; }
        public List<FoodcourtCheckProduct> FoodcourtCheckProducts { get; set; }
    }
}
