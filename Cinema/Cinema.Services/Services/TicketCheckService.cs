using AutoMapper;
using Cinema.Core.Abstractions;
using Cinema.Core.Abstractions.Services;
using Cinema.Core.Entities;

namespace Cinema.Services.Services
{
    public class TicketCheckService : BaseService<TicketCheck, int>, ITicketCheckService
    {
        public TicketCheckService(IUnitOfWork unitOfWork, IMapper mapper) :
            base(unitOfWork, unitOfWork.TicketChecks, mapper)
        { }
    }
}
