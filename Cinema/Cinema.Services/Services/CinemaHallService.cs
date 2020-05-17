using AutoMapper;
using Cinema.Core.Abstractions;
using Cinema.Core.Abstractions.Services;
using Cinema.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.Services.Services
{
    public class CinemaHallService : BaseService<CinemaHall, int>, ICinemaHallService
    {
        public CinemaHallService(IUnitOfWork unitOfWork, IMapper mapper) :
            base(unitOfWork, unitOfWork.CinemaHalls, mapper)
        { }
        public List<CinemaHall> GetWithAll()
        {
            return repository.GetAll()
                .Include(l => l.Technology)
                .Include(m => m.CinemaLocation)
                .ToList();
        }
    }
}
