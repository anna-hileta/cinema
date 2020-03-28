using AutoMapper;
using Cinema.Core.Abstractions;
using Cinema.Core.Abstractions.Services;
using Cinema.Core.Entities;
using System;

namespace Cinema.Services.Services
{
    public class WorkerService : BaseService<Worker, Guid>, IWorkerService
    {
        public WorkerService(IUnitOfWork unitOfWork, IMapper mapper) :
            base(unitOfWork, unitOfWork.Workers, mapper)
        { }
    }
}
