using AutoMapper;
using Cinema.Core.Abstractions;
using Cinema.Core.Abstractions.Services;
using Cinema.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.Services.Services
{
    public class WorkerService : BaseService<Worker, Guid>, IWorkerService
    {
        public WorkerService(IUnitOfWork unitOfWork, IMapper mapper) :
            base(unitOfWork, unitOfWork.Workers, mapper)
        { }
        public List<Worker> GetWithAllInfo()
        {
            var u = repository.GetAll()
                .Include(m => m.Position)
                .ToList();

            return u;
        }
    }
}
