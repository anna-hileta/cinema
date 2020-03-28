using AutoMapper;
using Cinema.Core.Abstractions;
using Cinema.Core.Abstractions.Services;
using Cinema.Core.Entities;

namespace Cinema.Services.Services
{
    public class TechnologyService : BaseService<Technology, int>, ITechnologyService
    {
        public TechnologyService(IUnitOfWork unitOfWork, IMapper mapper) :
            base(unitOfWork, unitOfWork.Technologies, mapper)
        { }
    }
}
