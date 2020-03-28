using AutoMapper;
using Cinema.Core.Abstractions;
using Cinema.Core.Abstractions.Services;
using Cinema.Core.Entities;

namespace Cinema.Services.Services
{
    public class FoodProductsService : BaseService<FoodProducts, int>, IFoodProductsService
    {
        public FoodProductsService(IUnitOfWork unitOfWork, IMapper mapper) :
            base(unitOfWork, unitOfWork.FoodProducts, mapper)
        { }
    }
}
