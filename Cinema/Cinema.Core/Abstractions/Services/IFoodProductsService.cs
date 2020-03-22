using Cinema.Core.Entities;
using System.Collections.Generic;

namespace Cinema.Core.Abstractions.Services
{
    public interface IFoodProductsService
    {
        public List<Genre> Get();

        public FoodProducts GetById(int id);

        public FoodProducts Add(FoodProducts foodProducts);

        public FoodProducts Update(FoodProducts foodProducts);

        public void Delete(int id);
    }

}
