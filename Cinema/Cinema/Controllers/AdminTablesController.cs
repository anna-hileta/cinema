using Cinema.Core.Abstractions.Services;
using Cinema.Core.Entities;
using Cinema.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Controllers
{
    public class AdminTablesController : Controller
    {
        private readonly IMovieService movieService;
        private readonly IShowingService showingService;
        private readonly UserManager<Worker> userManager;
        private readonly SignInManager<Worker> signInManager;

        public AdminTablesController( IMovieService movieService, IShowingService showingService, UserManager<Worker> userManager, SignInManager<Worker> signInManager)
        {
            this.movieService = movieService;
            this.showingService = showingService;
            this.userManager = userManager;
            this.signInManager = signInManager;
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
        public IActionResult EditMovie(int index)
        {
            var movie = movieService.GetById(index);
            return View(new MovieViewModel() { movie = movie });
        }
    }


}