using Cinema.Core.Abstractions.Repositories;
using Cinema.Core.Entities;

namespace Cinema.DAL.Repositories
{
    public class WorkerRepository : BaseRepository<Worker, int>, IWorkerRepository
    {
        public WorkerRepository(CinemaContext cinemaContext): base(cinemaContext) { }
    }
}
