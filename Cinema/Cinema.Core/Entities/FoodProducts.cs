using System.Collections.Generic;

namespace Cinema.Core.Entities
{
    public class FoodProducts: IEntity<int>
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public List<FoodAmount> FoodAmounts { get; set; }
    }
}
