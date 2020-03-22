using Cinema.Core.Entities;
using System.Collections.Generic;

namespace Cinema.Core.Abstractions.Services
{
    public interface IDirectorService
    {
        public List<Director> Get();

        public Director GetById(int id);

        public Director Add(Director director);

        public Director Update(Director director);

        public void Delete(int id);
    }

}
