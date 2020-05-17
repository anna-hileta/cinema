using AutoMapper;
using Cinema.Core.Abstractions;
using Cinema.Core.Abstractions.Services;
using Cinema.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.Services.Services
{
    public class FoodAmountService : BaseService<FoodAmount, int>, IFoodAmountService
    {
        public FoodAmountService(IUnitOfWork unitOfWork, IMapper mapper) :
            base(unitOfWork, unitOfWork.FoodAmounts, mapper)
        { }
        public List<FoodAmount> GetWithAll()
        {
            return repository.GetAll()
                .Include(l => l.FoodProducts)
                .Include(m => m.CinemaLocation)
                .ToList();
        }
    }
}
