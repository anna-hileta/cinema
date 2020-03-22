using Cinema.Core.Entities;
using System.Collections.Generic;

namespace Cinema.Core.Abstractions.Services
{
    public interface ITechnologyService
    {
        public List<Technology> Get();

        public Technology GetById(int id);

        public Technology Add(Technology technology);

        public Technology Update(Technology technology);

        public void Delete(int id);
    }

}
