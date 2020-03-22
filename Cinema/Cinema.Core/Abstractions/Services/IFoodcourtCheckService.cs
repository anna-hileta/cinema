using Cinema.Core.Entities;
using System.Collections.Generic;

namespace Cinema.Core.Abstractions.Services
{
    public interface IFoodcourtCheckService
    {
        public List<Genre> Get();

        public FoodcourtCheck GetById(int id);

        public FoodcourtCheck Add(FoodcourtCheck foodcourtCheck);

        public FoodcourtCheck Update(FoodcourtCheck foodcourtCheck);

        public void Delete(int id);
    }

}
