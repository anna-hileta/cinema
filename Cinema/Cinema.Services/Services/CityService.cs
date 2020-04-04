using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Cinema.Core.Abstractions;
using Cinema.Core.Abstractions.Services;
using Cinema.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.Services
{
    public class CityService : BaseService<City, int>, ICityService
    {
        public CityService(IUnitOfWork unitOfWork, IMapper mapper) :
            base(unitOfWork, unitOfWork.Cities, mapper)
        { }

        public List<City> GetWithLocations()
        {
            return repository.GetAll().Include(l => l.CinemaLocations).ToList();
        }
    }

}
