using AutoMapper;
using Cinema.Core.Abstractions;
using Cinema.Core.Abstractions.Services;
using Cinema.Core.Entities;

namespace Cinema.Services.Services
{
    public class FoodcourtCheckProductService : BaseService<FoodcourtCheckProduct , int>, IFoodcourtCheckProductService
    {
        public FoodcourtCheckProductService(IUnitOfWork unitOfWork, IMapper mapper) :
            base(unitOfWork, unitOfWork.FoodcourtCheckProducts, mapper)
        { }
    }
}
