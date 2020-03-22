using Cinema.Core.Entities;
using System.Collections.Generic;

namespace Cinema.Core.Abstractions.Services
{
    public interface IPositionService
    {
        public List<Position> Get();

        public Position GetById(int id);

        public Position Add(Position position);

        public Position Update(Position position);

        public void Delete(int id);
    }

}
