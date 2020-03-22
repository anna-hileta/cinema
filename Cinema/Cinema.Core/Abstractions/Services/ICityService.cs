using Cinema.Core.Entities;
using System.Collections.Generic;

namespace Cinema.Core.Abstractions.Services
{
    public interface ICityService
    {
        public List<City> Get();

        public City GetById(int id);

        public City Add(City city);

        public City Update(City city);

        public void Delete(int id);
    }

}
