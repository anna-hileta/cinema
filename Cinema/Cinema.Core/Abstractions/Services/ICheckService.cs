using Cinema.Core.Entities;
using System.Collections.Generic;

namespace Cinema.Core.Abstractions.Services
{
    public interface ICheckService : IBasicService<Check, int> {
        public Check GetWithAllInfo(int id);
    }
    
}
