using Cinema.Core.Abstractions.Repositories;
using Cinema.Core.Entities;

namespace Cinema.DAL.Repositories
{
    public class FoodAmountRepository: BaseRepository<FoodAmount, int>, IFoodAmountRepository
    {
        public FoodAmountRepository(CinemaContext cinemaContext): base(cinemaContext) { }
    }
}
