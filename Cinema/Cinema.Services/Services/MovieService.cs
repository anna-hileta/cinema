using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Cinema.Core.Abstractions;
using Cinema.Core.Abstractions.Services;
using Cinema.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.Services
{
    public class MovieService : BaseService<Movie, int>, IMovieService
    {
        public MovieService(IUnitOfWork unitOfWork, IMapper mapper) :
            base(unitOfWork, unitOfWork.Movies, mapper)
        { }

        public List<Movie> GetWithAllInfo()
        {
            var u = repository.GetAll()
                .Include(l => l.MovieGenres)
                .ThenInclude(g => g.Genre)
                .Include(d => d.Director)
                .Include(c => c.CountryOfOrigin)
                .Include(s => s.Showings)  
                .ThenInclude(ch => ch.CinemaHall)
                .ThenInclude(ch => ch.Technology)
                .Include(s => s.Showings)
                .ThenInclude(ch => ch.Tickets)
                .ToList();
            return u;
        }

        public Movie GetWithAllInfoForOne(int id)
        {
            var u = GetWithAllInfo();
            var theOne = u.Find(m => m.Id == id);
            return theOne;
        }
    }
}
