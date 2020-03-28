using AutoMapper;
using Cinema.Core.Abstractions;
using Cinema.Core.Abstractions.Services;
using Cinema.Core.Entities;

namespace Cinema.Services.Services
{
    public class CinemaHallService : BaseService<CinemaHall, int>, ICinemaHallService
    {
        public CinemaHallService(IUnitOfWork unitOfWork, IMapper mapper) :
            base(unitOfWork, unitOfWork.CinemaHalls, mapper)
        { }
    }
}
