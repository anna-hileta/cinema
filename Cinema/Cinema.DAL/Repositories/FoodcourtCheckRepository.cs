using Cinema.Core.Abstractions.Repositories;
using Cinema.Core.Entities;

namespace Cinema.DAL.Repositories
{
    public class FoodcourtCheckRepository : BaseRepository<FoodcourtCheck, int>, IFoodcourtCheckRepository
    {
        public FoodcourtCheckRepository(CinemaContext cinemaContext): base(cinemaContext) { }
    }
}
