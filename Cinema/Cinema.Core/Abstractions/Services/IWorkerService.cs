using Cinema.Core.Entities;
using System;
using System.Collections.Generic;

namespace Cinema.Core.Abstractions.Services
{
    public interface IWorkerService : IBasicService<Worker, Guid> {
        public List<Worker> GetWithAllInfo();
    }

}
