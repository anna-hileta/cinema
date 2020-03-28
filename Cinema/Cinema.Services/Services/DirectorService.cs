using AutoMapper;
using Cinema.Core.Abstractions;
using Cinema.Core.Abstractions.Services;
using Cinema.Core.Entities;

namespace Cinema.Services.Services
{
    public class DirectorService : BaseService<Director, int>, IDirectorService
    {
        public DirectorService(IUnitOfWork unitOfWork, IMapper mapper) :
            base(unitOfWork, unitOfWork.Directors, mapper)
        { }
    }
}
