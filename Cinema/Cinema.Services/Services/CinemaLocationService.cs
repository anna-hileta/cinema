using System.Collections.Generic;
using AutoMapper;
using Cinema.Core.Abstractions;
using Cinema.Core.Abstractions.Services;
using Cinema.Core.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.Services
{
    public class CinemaLocationService : BaseService<CinemaLocation, int>, ICinemaLocationService
    {
        public CinemaLocationService(IUnitOfWork unitOfWork, IMapper mapper) :
            base(unitOfWork, unitOfWork.CinemaLocations, mapper)
        { }

        public List<CinemaLocation> GetWithCities()
        {
            return repository.GetAll().Include(l => l.City).ToList();
        }
    }
}
