using System;
using System.Collections.Generic;

namespace Cinema.Core.Entities
{
    public class FoodcourtCheck: IEntity<int>
    {
        public int Id { get; set; }
        public DateTime TransactionDateAndTime { get; set; }
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }
        public decimal PaidPrice { get; set; }
        public List<FoodcourtCheckProduct> FoodcourtCheckProducts { get; set; }
    }
}
