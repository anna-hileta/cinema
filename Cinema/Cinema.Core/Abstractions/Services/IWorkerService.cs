using Cinema.Core.Entities;
using System.Collections.Generic;

namespace Cinema.Core.Abstractions.Services
{
    public interface IWorkerService
    {
        public List<Worker> Get();

        public Worker GetById(int id);

        public Worker Add(Worker worker);

        public Worker Update(Worker worker);

        public void Delete(int id);
    }

}
