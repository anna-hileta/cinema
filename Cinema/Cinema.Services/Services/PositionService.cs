using AutoMapper;
using Cinema.Core.Abstractions;
using Cinema.Core.Abstractions.Services;
using Cinema.Core.Entities;

namespace Cinema.Services.Services
{
    public class PositionService : BaseService<Position, int>, IPositionService
    {
        public PositionService(IUnitOfWork unitOfWork, IMapper mapper) :
            base(unitOfWork, unitOfWork.Positions, mapper)
        { }
    }
}
