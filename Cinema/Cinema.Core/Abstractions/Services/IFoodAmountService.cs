using Cinema.Core.Entities;
using System.Collections.Generic;

namespace Cinema.Core.Abstractions.Services
{
    public interface IFoodAmountService
    {
        public List<Genre> Get();

        public FoodAmount GetById(int id);

        public FoodAmount Add(FoodAmount foodAmount);

        public FoodAmount Update(FoodAmount foodAmount);

        public void Delete(int id);
    }

}
