using AutoMapper;
using Cinema.Core.Abstractions;
using Cinema.Core.Abstractions.Services;
using Cinema.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Cinema.Services.Services
{
    public class FoodcourtCheckService : BaseService<FoodcourtCheck, int>, IFoodcourtCheckService
    {
        public FoodcourtCheckService(IUnitOfWork unitOfWork, IMapper mapper) :
            base(unitOfWork, unitOfWork.FoodcourtChecks, mapper)
        { }
        public FoodcourtCheck GetWithAllInfo(int id)
        {
            var u = repository.GetAll()
                .Where(m => m.Id == id)
                .Include(m => m.Worker)
                .ThenInclude(m => m.Position)
                .Include(m => m.FoodcourtCheckProducts)
                .ThenInclude(m => m.FoodAmount)
                .ThenInclude(m => m.FoodProducts)
                .First();

            return u;
        }
    }
}
