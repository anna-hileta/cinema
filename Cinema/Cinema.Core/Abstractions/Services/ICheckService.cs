using Cinema.Core.Entities;
using System.Collections.Generic;

namespace Cinema.Core.Abstractions.Services
{
    public interface ICheckService
    {
        public List<Check> Get();

        public Check GetById(int id);

        public Check Add(Check check);

        public Check Update(Check check);

        public void Delete(int id);
    }

}
