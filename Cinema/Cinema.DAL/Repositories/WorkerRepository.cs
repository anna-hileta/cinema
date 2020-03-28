using Cinema.Core.Abstractions.Repositories;
using Cinema.Core.Entities;
using System;

namespace Cinema.DAL.Repositories
{
    public class WorkerRepository : BaseRepository<Worker, Guid>, IWorkerRepository
    {
        public WorkerRepository(CinemaContext cinemaContext): base(cinemaContext) { }
    }
}
