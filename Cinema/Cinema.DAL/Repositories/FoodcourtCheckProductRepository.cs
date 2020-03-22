using Cinema.Core.Abstractions.Repositories;
using Cinema.Core.Entities;

namespace Cinema.DAL.Repositories
{
    public class FoodcourtCheckProductRepository : BaseRepository<FoodcourtCheckProduct, int>, IFoodcourtCheckProductRepository
    {
        public FoodcourtCheckProductRepository(CinemaContext cinemaContext): base(cinemaContext) { }
    }
}
