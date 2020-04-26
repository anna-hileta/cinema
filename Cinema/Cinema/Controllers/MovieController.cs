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
    public class MovieController : Controller
    {
        private readonly IMovieService movieService;
        private readonly IShowingService showingService;
        private readonly UserManager<Worker> userManager;
        private readonly SignInManager<Worker> signInManager;

        public MovieController( IMovieService movieService, IShowingService showingService, UserManager<Worker> userManager, SignInManager<Worker> signInManager)
        {
            this.movieService = movieService;
            this.showingService = showingService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            var movie = movieService.Get();
            return View(new MovieViewModel() { movies = movie});
        }
        public IActionResult Movie(int index)
        {
            var movies = movieService.GetWithAllInfo();
            var movie = movies.Where(m => m.Id == index)
                 .First();
            return View(new MovieViewModel() { movie = movie });
        }
        public IActionResult MovieShowing(int showingId)
        {
            var movie = showingService.GetShowingInfo(showingId);
            return View(new ShowingViewModel() { showings = movie });
        }
    }


}