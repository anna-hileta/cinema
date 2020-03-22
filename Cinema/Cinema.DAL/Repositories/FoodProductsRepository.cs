using Cinema.Core.Abstractions.Repositories;
using Cinema.Core.Entities;

namespace Cinema.DAL.Repositories
{
    public class FoodProductsRepository : BaseRepository<FoodProducts, int>, IFoodProductsRepository
    {
        public FoodProductsRepository(CinemaContext cinemaContext): base(cinemaContext) { }
    }
}
