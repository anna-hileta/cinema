using Cinema.Core.Entities;
using System.Collections.Generic;

namespace Cinema.Core.Abstractions.Services
{
    public interface IShowingService
    {
        public List<Showing> Get();

        public Showing GetById(int id);

        public Showing Add(Showing showing);

        public Showing Update(Showing showing);

        public void Delete(int id);
    }

}
