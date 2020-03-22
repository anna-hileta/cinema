using Cinema.Core.Entities;
using System.Collections.Generic;

namespace Cinema.Core.Abstractions.Services
{
    public interface IFoodcourtCheckProductService
    {
        public List<Genre> Get();

        public FoodcourtCheckProduct GetById(int id);

        public FoodcourtCheckProduct Add(FoodcourtCheckProduct foodcourtCheckProduct);

        public FoodcourtCheckProduct Update(FoodcourtCheckProduct foodcourtCheckProduct);

        public void Delete(int id);
    }

}
