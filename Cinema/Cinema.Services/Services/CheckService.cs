using AutoMapper;
using Cinema.Core.Abstractions;
using Cinema.Core.Abstractions.Services;
using Cinema.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.Services.Services
{
    public class CheckService : BaseService<Check, int>, ICheckService
    {
        public CheckService(IUnitOfWork unitOfWork, IMapper mapper) :
            base(unitOfWork, unitOfWork.Checks, mapper)
        { }
        public Check GetWithAllInfo(int id)
        {
            var u = repository.GetAll()
                .Where(m => m.Id == id)
                .Include(m => m.Worker)
                .ThenInclude(m => m.Position)
                .Include(m => m.TicketChecks)
                .ThenInclude(c => c.Ticket)
                .ThenInclude(s => s.Showing)
                .ThenInclude(m => m.Movie)
                .Include(m => m.TicketChecks)
                .ThenInclude(c => c.Ticket)
                .ThenInclude(s => s.Showing)
                .ThenInclude(s => s.CinemaHall)
                .ThenInclude(s => s.CinemaLocation)
                .First();

            return u;
        }
    }
}
