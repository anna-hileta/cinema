using Cinema.Core.Entities;
using System.Collections.Generic;

namespace Cinema.Core.Abstractions.Services
{
    public interface IFoodAmountService : IBasicService<FoodAmount, int> {
        public List<FoodAmount> GetWithAll();

    }
}
