using Cinema.Core.Abstractions.Services;
using Cinema.Core.Entities;
using Cinema.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Controllers
{
    public class AdminTablesController : Controller
    {
        private readonly IMovieService movieService;
        private readonly IGenreService genreService;
        private readonly IWorkerService workerService;
        private readonly IDirectorService directorService;
        private readonly ICountryOfOriginService countryOfOriginService;
        private readonly ICinemaLocationService cinemaLocationService;
        private readonly IFoodAmountService foodAmountService;
        private readonly IShowingService showingService;
        private readonly ICinemaHallService cinemaHallService;
        private readonly UserManager<Worker> userManager;
        private readonly SignInManager<Worker> signInManager;

        public AdminTablesController(ICinemaLocationService cinemaLocationService, IFoodAmountService foodAmountService, ICinemaHallService cinemaHallService, IDirectorService directorService, IWorkerService workerService, ICountryOfOriginService countryOfOriginService, IMovieService movieService, IGenreService genreService, IShowingService showingService, UserManager<Worker> userManager, SignInManager<Worker> signInManager)
        {
            this.directorService = directorService;
            this.foodAmountService = foodAmountService;
            this.cinemaHallService = cinemaHallService;
            this.cinemaLocationService = cinemaLocationService;
            this.countryOfOriginService = countryOfOriginService;
            this.movieService = movieService;
            this.workerService = workerService;
            this.genreService = genreService;
            this.showingService = showingService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MovieTable()
        {
            var movie = movieService.GetWithAllInfo();
            return View(new MovieViewModel() { movies = movie});
        }
        public IActionResult DeleteMovie(int index)
        {
            movieService.Delete(index);
            return RedirectToAction("MovieTable");
        }
        public IActionResult MovieEdit(int index)
        {
            var genres = genreService.Get();
            var movie = movieService.GetWithAllInfoForOne(index);
            return View(new EditMovieViewModel() { id = movie.Id, CountryOfOrigin = movie.CountryOfOrigin.Name,
                Description = movie.Description, DirectorName = movie.Director.DirectorName,
                EndDate = movie.EndDate, Length = movie.Length, Poster = movie.Poster,
                PremiereDate = movie.PremiereDate, Title = movie.Title, genre = genres});
        }
        [HttpPost]
        public IActionResult Edit(EditMovieViewModel model)
        {
            var movie = movieService.GetById(model.id);
            movie.Length = model.Length;
            movie.Title = model.Title;
            movie.EndDate = model.EndDate;
            movie.PremiereDate = model.PremiereDate;
            movie.Poster = model.Poster;
            movie.Description = model.Description;

            var director = directorService.Get().Where(m => m.DirectorName == model.DirectorName).FirstOrDefault();
            if(director != null)
            {
                movie.DirectorId = director.Id;
                movie.Director = director;
            }
            else
            {
                director = directorService.Add(new Director()
                {
                    DirectorName = model.DirectorName
                });
                movie.DirectorId = director.Id;
                movie.Director = director;
            }
            var countryOfOrigin = countryOfOriginService.Get().Where(m => m.Name == model.CountryOfOrigin).FirstOrDefault();
            if (countryOfOrigin != null)
            {
                movie.CountryOfOriginId = countryOfOrigin.Id;
                movie.CountryOfOrigin = countryOfOrigin;
            }
            else
            {
                countryOfOrigin = countryOfOriginService.Add(new CountryOfOrigin()
                {
                    Name = model.CountryOfOrigin
                });
                movie.CountryOfOriginId = countryOfOrigin.Id;
                movie.CountryOfOrigin = countryOfOrigin;
            }
            movieService.Update(movie);
            return RedirectToAction("MovieTable");
        }
        public IActionResult WorkerTable()
        {
            var worker = workerService.GetWithAllInfo();
            return View(new WorkerViewModel() { workers = worker });
        }
        public IActionResult DeleteWorker(string index)
        {
            workerService.Delete(Guid.Parse(index));
            return RedirectToAction("WorkerTable");
        }
        public IActionResult CinemaLocationTable()
        {
            var cinemaLocations = cinemaLocationService.GetWithCities();
            return View(new CinemaLocationViewModel() { cinemaLocations = cinemaLocations });
        }
        public IActionResult DeleteCinemaLocation(int index)
        {
            cinemaLocationService.Delete(index);
            return RedirectToAction("CinemaLocationTable");
        }
        public IActionResult CinemaHallTable()
        {
            var cinemaHalls = cinemaLocationService.GetWithHalls();
            return View(new CinemaLocationViewModel() { cinemaLocations = cinemaHalls });
        }
        public IActionResult DeleteCinemaHall(int index)
        {
            cinemaHallService.Delete(index);
            return RedirectToAction("CinemaHallTable");
        }
        public IActionResult ShowingTable()
        {
            var showings = showingService.GetShowingsInfo();
            return View(new ShowingsViewModel() { showings = showings });
        }
        public IActionResult DeleteShowing(int index)
        {
            cinemaHallService.Delete(index);
            return RedirectToAction("CinemaHallTable");
        }
        public IActionResult FoodAmountsTable()
        {
            var foodAmount = foodAmountService.GetWithAll();
            return View(new FoodAmountsViewModel() { FoodAmounts = foodAmount });
        }
    }


}