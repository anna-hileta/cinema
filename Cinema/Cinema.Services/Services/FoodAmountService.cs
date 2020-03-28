using AutoMapper;
using Cinema.Core.Abstractions;
using Cinema.Core.Abstractions.Services;
using Cinema.Core.Entities;

namespace Cinema.Services.Services
{
    public class FoodAmountService : BaseService<FoodAmount, int>, IFoodAmountService
    {
        public FoodAmountService(IUnitOfWork unitOfWork, IMapper mapper) :
            base(unitOfWork, unitOfWork.FoodAmounts, mapper)
        { }
    }
}
