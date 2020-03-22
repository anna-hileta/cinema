namespace Cinema.Core.Entities
{
    public class FoodcourtCheckProduct: IEntity<int>
    {
        public int Id { get; set; }
        public int FoodcourtCheckId { get; set; }
        public FoodcourtCheck FoodcourtCheck { get; set; }
        public int FoodAmountId { get; set; }
        public FoodAmount FoodAmount { get; set; }
        public int AmountOfProduct { get; set; }
    }
}
