using AutoMapper;
using Cinema.Core.Abstractions;
using Cinema.Core.Abstractions.Services;
using Cinema.Core.Entities;

namespace Cinema.Services.Services
{
    public class CinemaLocationService : BaseService<CinemaLocation, int>, ICinemaLocationService
    {
        public CinemaLocationService(IUnitOfWork unitOfWork, IMapper mapper) :
            base(unitOfWork, unitOfWork.CinemaLocations, mapper)
        { }
    }
}
