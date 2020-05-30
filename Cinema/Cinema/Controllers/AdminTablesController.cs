using Cinema.Core.Abstractions.Services;
using Cinema.Core.Entities;
using Cinema.DAL;
using Cinema.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WM.MDBBlazor;

namespace Cinema.Controllers
{
    public class AdminTablesController : Controller
    {
        private readonly IMovieService movieService;
        private readonly IGenreService genreService;
        private readonly ICityService cityService;
        private readonly IWorkerService workerService;
        private readonly ITechnologyService technologyService;
        private readonly IDirectorService directorService;
        private readonly ICountryOfOriginService countryOfOriginService;
        private readonly CinemaContext context;
        private readonly ITicketCheckService ticketCheckService;
        private readonly IFoodcourtCheckProductService foodcourtCheckProductService;
        private readonly IFoodcourtCheckService foodcourtCheckService;
        private readonly ICheckService checkService;
        private readonly ITicketService ticketService;
        private readonly ICinemaLocationService cinemaLocationService;
        private readonly IFoodAmountService foodAmountService;
        private readonly IFoodProductsService foodProductsService;
        private readonly IShowingService showingService;
        private readonly ICinemaHallService cinemaHallService;
        private readonly UserManager<Worker> userManager;
        private readonly SignInManager<Worker> signInManager;

        public AdminTablesController(CinemaContext context, ITicketCheckService ticketCheckService, IFoodcourtCheckProductService foodcourtCheckProductService  ,IFoodcourtCheckService foodcourtCheckService, ICheckService checkService, ITicketService ticketService, ICinemaLocationService cinemaLocationService, IFoodProductsService foodProductsService, ITechnologyService technologyService, ICityService cityService, IFoodAmountService foodAmountService, ICinemaHallService cinemaHallService, IDirectorService directorService, IWorkerService workerService, ICountryOfOriginService countryOfOriginService, IMovieService movieService, IGenreService genreService, IShowingService showingService, UserManager<Worker> userManager, SignInManager<Worker> signInManager)
        {
            this.foodProductsService = foodProductsService;
            this.directorService = directorService;
            this.technologyService = technologyService;
            this.cityService = cityService;
            this.foodAmountService = foodAmountService;
            this.cinemaHallService = cinemaHallService;
            this.context = context;
            this.ticketCheckService = ticketCheckService;
            this.foodcourtCheckProductService = foodcourtCheckProductService;
            this.foodcourtCheckService = foodcourtCheckService;
            this.checkService = checkService;
            this.ticketService = ticketService;
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
            var movie = movieService.GetWithAllInfoForOne(index);
            var genres = genreService.Get().Select(a => new GenreSelectionViewModel() { 
                GenreId = a.Id,
                GenreName = a.GenreName,
                IsSelected = movie.MovieGenres.Where(b => b.GenreId == a.Id).Any()
            }).ToList();
            return View(new EditMovieViewModel() { id = movie.Id, CountryOfOrigin = movie.CountryOfOrigin.Name,
                Description = movie.Description, DirectorName = movie.Director.DirectorName,
                EndDate = movie.EndDate, Length = movie.Length, Poster = movie.Poster,
                PremiereDate = movie.PremiereDate, Title = movie.Title, genre = genres});
        }
        [HttpPost]
        public IActionResult Edit(EditMovieViewModel model)
        {
            var movie = movieService.GetByIdQueryable(model.id)
                .Include(a => a.MovieGenres).First();
            movie.Length = model.Length;
            movie.Title = model.Title;
            movie.EndDate = model.EndDate;
            movie.PremiereDate = model.PremiereDate;
            movie.Poster = model.Poster;
            movie.Description = model.Description;
            var genres = Request.Form["genre"];
            foreach(var genre in genres)
            {
                var genreId = int.Parse(genre);
                if (movie.MovieGenres.Find(a => a.GenreId == genreId) == null)
                {
                    movie.MovieGenres.Add(new MovieGenre()
                    {
                        GenreId = genreId,
                        MovieId = movie.Id
                    });
                }
            }

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
        public IActionResult MovieCreate()
        {
            var genres = genreService.Get().Select(a => new GenreSelectionViewModel()
            {
                GenreId = a.Id,
                GenreName = a.GenreName,
                IsSelected = false
            }).ToList();
            return View(new EditMovieViewModel()
            {
                genre = genres
            });
        }
        [HttpPost]
        public IActionResult MovieCreate(EditMovieViewModel model, string MovieTitle, string CountryOfOrigin, string DirectorName, DateTime PremiereDate, DateTime EndDate, DateTime Length, string Poster, string Description)
        {
            var movie = new Movie() {
                Description = Description,
                EndDate = EndDate,
                Length = Length,
                Poster = Poster,
                PremiereDate = PremiereDate,
                Title = MovieTitle,
                MovieGenres = new List<MovieGenre>()
            };
            var director = directorService.Get().Find(a => a.DirectorName == DirectorName);
            if (director != null)
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
            var genres = Request.Form["genre"];
            foreach (var genre in genres)
            {
                var genreId = int.Parse(genre);
                movie.MovieGenres.Add(new MovieGenre()
                {
                    GenreId = genreId,
                    MovieId = movie.Id
                });
            }
            var countryOfOrigin = countryOfOriginService.Get().Where(m => m.Name == CountryOfOrigin).FirstOrDefault();
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
            movieService.Add(movie);
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
        public IActionResult CinemaCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CinemaCreate(string Address, string city, string CinemaName)
        {
            var CinemaLocation = new CinemaLocation()
            {
                Address = Address,
                CinemaHalls = new List<CinemaHall>(),
                CinemaName = CinemaName,
                FoodAmounts = new List<FoodAmount>()
            };
            var City = cityService.Get().Find(a => a.CityName == city);
            if (City != null)
            {
                CinemaLocation.CityId = City.Id;
                CinemaLocation.City = City;
            }
            else
            {
                City = cityService.Add(new City()
                {
                    CityName = city
                });
                CinemaLocation.CityId = City.Id;
                CinemaLocation.City = City;
            }
            cinemaLocationService.Add(CinemaLocation);
            return RedirectToAction("CinemaLocationTable");
        }

        public IActionResult CinemaEdit(int index)
        {
            var cinemas = cinemaLocationService.GetByIdQueryable(index)
                .Include(a => a.City).First();
            return View(new CinemasViewModel() { cinemaLocation = cinemas });
        }
        [HttpPost]
        public IActionResult CinemaEdit(int index, string Address, string city, string CinemaName)
        {
            var CinemaLocation = cinemaLocationService.GetById(index);
            CinemaLocation.Address = Address;
            CinemaLocation.CinemaName = CinemaName;

            var City = cityService.Get().Find(a => a.CityName == city);
            if (City != null)
            {
                CinemaLocation.CityId = City.Id;
                CinemaLocation.City = City;
            }
            else
            {
                City = cityService.Add(new City()
                {
                    CityName = city
                });
                CinemaLocation.CityId = City.Id;
                CinemaLocation.City = City;
            }
            cinemaLocationService.Update(CinemaLocation);
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
        public IActionResult CinemaHallCreate()
        {
            var technologies = technologyService.Get();
            var cinemas = cinemaLocationService.Get();
            return View(new CinemaLocationsAndTechnologyViewModel() { cinemaLocations = cinemas, technologies = technologies});
        }
        [HttpPost]
        public IActionResult CinemaHallCreate(string Name, string Rows, string Seats, int Technology, int Cinema)
        {
            var CinemaHall = new CinemaHall()
            {
                Name = Name,
                RowsCount = int.Parse(Rows),
                SeatsCount = int.Parse(Seats)
            };
            var technology = technologyService.GetById(Technology);
            CinemaHall.TechnologyId = technology.Id;
            CinemaHall.Technology = technology;
            var CinemaLocation = cinemaLocationService.GetById(Cinema);
            CinemaHall.CinemaLocationId = CinemaLocation.Id;
            CinemaHall.CinemaLocation = CinemaLocation;

            cinemaHallService.Add(CinemaHall);
            return RedirectToAction("CinemaHallTable");
        }
        public IActionResult CinemaHallEdit(int index)
        {
            var cinemaHall = cinemaHallService.GetById(index);
            var technologies = technologyService.Get();
            var cinemas = cinemaLocationService.Get();
            return View(new CinemaLocationsAndTechnologyViewModel() { cinemaHall = cinemaHall, cinemaLocations = cinemas, technologies = technologies });
        }
        [HttpPost]
        public IActionResult CinemaHallEdit(int index, string Name, string Rows, string Seats, int Technology)
        {
            var CinemaHall = cinemaHallService.GetById(index);
            CinemaHall.Name = Name;
            CinemaHall.RowsCount = int.Parse(Rows);
            CinemaHall.SeatsCount = int.Parse(Seats);
            var technology = technologyService.GetById(Technology);
            CinemaHall.TechnologyId = technology.Id;
            CinemaHall.Technology = technology;

            cinemaHallService.Update(CinemaHall);
            return RedirectToAction("CinemaHallTable");
        }
        public IActionResult ShowingTable()
        {
            var showings = showingService.GetShowingsInfo();
            return View(new ShowingsViewModel() { showings = showings });
        }
        public IActionResult ShowingCreate()
        {
            var movies = movieService.Get().FindAll(a => a.EndDate >= DateTime.Today).ToList();
            var cinemas = cinemaLocationService.GetWithHalls();
            List<Tuple<int, string>> cinemaLocations = new List<Tuple<int, string>>();
            string temp;
            foreach(var item in cinemas)
            {
                foreach(var hall in item.CinemaHalls)
                {
                    temp = item.CinemaName + ", Hall " + hall.Name;
                    cinemaLocations.Add(new Tuple<int, string>(hall.Id, temp));
                }
            }
            return View(new ShowingCreateAndEditViewModel() { cinemaLocations = cinemaLocations, movies = movies , IsSuccessfull = true});
        }
        [HttpPost]
        public IActionResult ShowingCreate(int Cinema, int Movie, DateTime DateAndTime)
        {
            /*
            var Showing = new Showing()
            {
                DateAndTime = DateAndTime
            };
            var CinemaHall = cinemaHallService.GetById(Cinema);
            Showing.CinemaHallId = Cinema;
            Showing.CinemaHall = CinemaHall;
            var movie = movieService.GetById(Movie);
            Showing.MovieId = Movie;
            Showing.Movie = movie;

            showingService.Add(Showing);
            */

            /*PROCEDURE AddNewShowing  
           (  
           @HallId int,
           @StartDate datetime,
           @MovieLength datetime,
           @MovieId int */
            var CinemaHall = cinemaHallService.GetById(Cinema);
            var movie = movieService.GetById(Movie);
            SqlParameter[] @params =
            {
               new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
               new SqlParameter("@HallId", SqlDbType.Int){ Value = CinemaHall.Id},
               new SqlParameter("@StartDate", SqlDbType.DateTime){ Value = DateAndTime},
               new SqlParameter("@MovieLength", SqlDbType.DateTime){ Value = movie.Length},
               new SqlParameter("@MovieId", SqlDbType.Int){ Value = movie.Id}
             };

            context.Database.ExecuteSqlCommand("exec AddNewShowing @returnVal OUT, @HallId, @StartDate, @MovieLength, @MovieId", @params);

            var result = (int)@params[0].Value;
            if (result == 0)
            {
                return RedirectToAction("ShowingTable");
            }
            else
            {
                var cinemas = cinemaLocationService.GetWithHalls();
                List<Tuple<int, string>> cinemaLocations = new List<Tuple<int, string>>();
                string temp;
                foreach (var item in cinemas)
                {
                    foreach (var hall in item.CinemaHalls)
                    {
                        temp = item.CinemaName + ", Hall " + hall.Name;
                        cinemaLocations.Add(new Tuple<int, string>(hall.Id, temp));
                    }
                }
                var movies = movieService.Get().FindAll(a => a.EndDate >= DateTime.Today).ToList();
                return View("ShowingCreate", new ShowingCreateAndEditViewModel() { cinemaLocations = cinemaLocations, movies = movies, IsSuccessfull = false });
            }
        }
        public IActionResult ShowingEdit(int index)
        {
            var showing = showingService.GetById(index);
            var movies = movieService.Get().FindAll(a => a.EndDate >= DateTime.Today).ToList();
            var cinemas = cinemaLocationService.GetWithHalls();
            List<Tuple<int, string>> cinemaLocations = new List<Tuple<int, string>>();
            string temp;
            foreach (var item in cinemas)
            {
                foreach (var hall in item.CinemaHalls)
                {
                    temp = item.CinemaName + ", Hall " + hall.Name;
                    cinemaLocations.Add(new Tuple<int, string>(hall.Id, temp));
                }
            }
            return View(new ShowingCreateAndEditViewModel() { showing = showing, cinemaLocations = cinemaLocations, movies = movies, IsSuccessfull= true });
        }
        [HttpPost]
        [Obsolete]
        public IActionResult ShowingEdit(int index, int Cinema, int Movie, DateTime DateAndTime)
        {
            var CinemaHall = cinemaHallService.GetById(Cinema);
            var movie = movieService.GetById(Movie);
            var showing = showingService.GetById(index);
            SqlParameter[] @params =
            {
               new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
               new SqlParameter("@ShowingId", SqlDbType.Int){ Value = index},
               new SqlParameter("@HallId", SqlDbType.Int){ Value = CinemaHall.Id},
               new SqlParameter("@StartDate", SqlDbType.DateTime){ Value = DateAndTime},
               new SqlParameter("@MovieLength", SqlDbType.DateTime){ Value = movie.Length},
               new SqlParameter("@MovieId", SqlDbType.Int){ Value = movie.Id}
             };


            context.Database.ExecuteSqlCommand("exec UpdateShowing @returnVal OUT, @ShowingId, @HallId, @StartDate, @MovieLength, @MovieId", @params);

            var result = (int) @params[0].Value;
            if(result == 0)
            {
                return RedirectToAction("ShowingTable");
            }
            else
            {
                var cinemas = cinemaLocationService.GetWithHalls();
                List<Tuple<int, string>> cinemaLocations = new List<Tuple<int, string>>();
                string temp;
                foreach (var item in cinemas)
                {
                    foreach (var hall in item.CinemaHalls)
                    {
                        temp = item.CinemaName + ", Hall " + hall.Name;
                        cinemaLocations.Add(new Tuple<int, string>(hall.Id, temp));
                    }
                }
                var movies = movieService.Get().FindAll(a => a.EndDate >= DateTime.Today).ToList();
                return View("ShowingEdit",new ShowingCreateAndEditViewModel() { showing = showing, cinemaLocations = cinemaLocations, movies = movies, IsSuccessfull = false });
            }
        }
        public IActionResult DeleteShowing(int index)
        {
            cinemaHallService.Delete(index);
            return RedirectToAction("CinemaHallTable");
        }
        public IActionResult DeleteFoodAmount(int index)
        {
            foodAmountService.Delete(index);
            return RedirectToAction("FoodAmountsTable");
        }
        public IActionResult FoodAmountsTable()
        {
            var foodAmount = foodAmountService.GetWithAll();
            return View(new FoodAmountsViewModel() { FoodAmounts = foodAmount });
        }
        public IActionResult FoodAmountCreate()
        {
            var foodProduct = foodProductsService.Get();
            var cinemas = cinemaLocationService.Get();
            return View(new CinemaLocationAndFoodProductViewModel() { cinemaLocations = cinemas, foodProducts = foodProduct });
        }
        [HttpPost]
        public IActionResult FoodAmountCreate(string Amount, int CinemaLocation, int FoodProductId)
        {
            var CinemaLocationCurrent = cinemaLocationService.GetById(CinemaLocation);
            var FoodProduct = foodProductsService.GetById(FoodProductId);
            var possibleItem =  foodAmountService.Get().Find(m => (m.CinemaLocationId == CinemaLocationCurrent.Id && m.FoodProductsId == FoodProduct.Id));
            if(possibleItem != null)
            {
                possibleItem.ProductAmount = possibleItem.ProductAmount + int.Parse(Amount);
                foodAmountService.Update(possibleItem);
            }
            else
            {
                var FoodAmount = new FoodAmount()
                {
                    ProductAmount = int.Parse(Amount),
                };
                FoodAmount.CinemaLocation = CinemaLocationCurrent;
                FoodAmount.CinemaLocationId = CinemaLocationCurrent.Id;
                FoodAmount.FoodProducts = FoodProduct;
                FoodAmount.FoodProductsId = FoodProduct.Id;

                foodAmountService.Add(FoodAmount);
            }
            return RedirectToAction("FoodAmountsTable");
        }
        public IActionResult FoodAmountEdit(int index)
        {
            var FoodAmount = foodAmountService.GetByIdQueryable(index).Include(v => v.CinemaLocation).Include(b => b.FoodProducts).First();
            return View(new CinemaLocationAndFoodProductViewModel() { foodAmount = FoodAmount });
        }
        [HttpPost]
        public IActionResult FoodAmountEdit(int index, string Amount)
        {
            var FoodAmount = foodAmountService.GetById(index);
            FoodAmount.ProductAmount = int.Parse(Amount);
            foodAmountService.Update(FoodAmount);
            return RedirectToAction("FoodAmountsTable");
        }
        public IActionResult StatisticByMonth()
        {
            var Tickets = checkService.Get().OrderBy(m => m.TransactionDateAndTime.Date).GroupBy(m => m.TransactionDateAndTime.Date);
            DateTime MaxDate = DateTime.MinValue, MinDate = DateTime.MaxValue;
            List<DateTime> Day = new List<DateTime>();
            List<int> tickPerDay = new List<int>();
            var tickets = ticketCheckService.Get();
            foreach ( var tick in Tickets)
            {
                var a = tick.Key;
                if (a > MaxDate)
                    MaxDate = a;
                if (a < MinDate)
                    MinDate = a;
                var b = 0;
                foreach(var i in tick)
                {
                    b += tickets.FindAll(m => m.CheckId == i.Id).Count();
                }
                if(b != 0)
                {
                    Day.Add(a);
                    tickPerDay.Add(b);
                }
            }
            return View(new StatiticViewModel() {  MaxDate = MaxDate , MinDate = MinDate, ticksperDay = tickPerDay, Day = Day});
        }
        public IActionResult StatisticByMonthFood()
        {
            var Tickets = foodcourtCheckService.Get().OrderBy(m => m.TransactionDateAndTime.Date).GroupBy(m => m.TransactionDateAndTime.Date);
            DateTime MaxDate = DateTime.MinValue, MinDate = DateTime.MaxValue;
            List<DateTime> Day = new List<DateTime>();
            List<int> tickPerDay = new List<int>();
            var tickets = foodcourtCheckProductService.Get();
            foreach (var tick in Tickets)
            {
                var a = tick.Key;
                if (a > MaxDate)
                    MaxDate = a;
                if (a < MinDate)
                    MinDate = a;
                var b = 0;
                foreach (var i in tick)
                {
                    var temp = tickets.FindAll(m => m.FoodcourtCheckId == i.Id);
                    foreach (var j in temp)
                    {
                        b += j.AmountOfProduct;
                    }
                }
                if(b != 0)
                {
                    Day.Add(a);
                    tickPerDay.Add(b);
                }
            }
            return View(new StatiticViewModel() { MaxDate = MaxDate, MinDate = MinDate, ticksperDay = tickPerDay, Day = Day });
        }
    }


}