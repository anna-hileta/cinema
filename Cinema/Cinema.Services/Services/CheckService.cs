using AutoMapper;
using Cinema.Core.Abstractions;
using Cinema.Core.Abstractions.Services;
using Cinema.Core.Entities;

namespace Cinema.Services.Services
{
    public class CheckService : BaseService<Check, int>, ICheckService
    {
        public CheckService(IUnitOfWork unitOfWork, IMapper mapper) :
            base(unitOfWork, unitOfWork.Checks, mapper)
        { }
    }
}
