using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Cinema.Core.Abstractions;
using Cinema.Core.Abstractions.Services;
using Cinema.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.Services
{
    public class ShowingService : BaseService<Showing, int>, IShowingService
    {
        public ShowingService(IUnitOfWork unitOfWork, IMapper mapper) :
            base(unitOfWork, unitOfWork.Showings, mapper)
        { }
        public Showing GetShowingInfo(int showingId)
        {
            return repository.Find(s => s.Id == showingId)
                .Include(m => m.Movie)
                .Include(c => c.CinemaHall)
                .ThenInclude(d => d.Technology)
                .Include(c => c.Tickets)
                .Include(c => c.CinemaHall)
                .ThenInclude(c => c.CinemaLocation)
                .First();
        }
        public List<Showing> GetShowingsInfo()
        {
            return repository.GetAll()
                .Include(m => m.Movie)
                .Include(c => c.CinemaHall)
                .ThenInclude(d => d.CinemaLocation)
                .ToList();
        }
    }
}
