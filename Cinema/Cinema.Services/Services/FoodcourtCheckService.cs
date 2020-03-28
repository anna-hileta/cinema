using AutoMapper;
using Cinema.Core.Abstractions;
using Cinema.Core.Abstractions.Services;
using Cinema.Core.Entities;

namespace Cinema.Services.Services
{
    public class FoodcourtCheckService : BaseService<FoodcourtCheck, int>, IFoodcourtCheckService
    {
        public FoodcourtCheckService(IUnitOfWork unitOfWork, IMapper mapper) :
            base(unitOfWork, unitOfWork.FoodcourtChecks, mapper)
        { }
    }
}
