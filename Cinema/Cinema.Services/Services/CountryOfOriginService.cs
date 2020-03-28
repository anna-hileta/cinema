using AutoMapper;
using Cinema.Core.Abstractions;
using Cinema.Core.Abstractions.Services;
using Cinema.Core.Entities;

namespace Cinema.Services.Services
{
    public class CountryOfOriginService : BaseService<CountryOfOrigin, int>, ICountryOfOriginService
    {
        public CountryOfOriginService(IUnitOfWork unitOfWork, IMapper mapper) :
            base(unitOfWork, unitOfWork.CountryOfOrigins, mapper)
        { }
    }
}
