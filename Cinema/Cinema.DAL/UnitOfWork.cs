using Cinema.Core.Abstractions;
using Cinema.Core.Abstractions.Repositories;
using Cinema.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private CinemaContext context;

        public UnitOfWork(CinemaContext context)
        {
            this.context = context;
        }

        private ICityRepository cities;

        public ICityRepository Cities =>
            cities ??= new CityRepository(context);

        private ICheckRepository checks;

        public ICheckRepository Checks =>
            checks ??= new CheckRepository(context);

        private ICinemaHallRepository cinemaHalls;

        public ICinemaHallRepository CinemaHalls =>
            cinemaHalls ??= new CinemaHallRepository(context);

        private ICinemaLocationRepository cinemaLocations;

        public ICinemaLocationRepository CinemaLocations =>
            cinemaLocations ??= new CinemaLocationRepository(context);

        private ICountryOfOriginRepository countryOfOrigins;

        public ICountryOfOriginRepository CountryOfOrigins =>
            countryOfOrigins ??= new CountryOfOriginRepository(context);

        private IDirectorRepository directors;

        public IDirectorRepository Directors =>
            directors ??= new DirectorRepository(context);

        private IFoodAmountRepository foodAmounts;

        public IFoodAmountRepository FoodAmounts =>
            foodAmounts ??= new FoodAmountRepository(context);

        private IFoodcourtCheckProductRepository foodcourtCheckProducts;

        public IFoodcourtCheckProductRepository FoodcourtCheckProducts =>
            foodcourtCheckProducts ??= new FoodcourtCheckProductRepository(context);

        private IFoodcourtCheckRepository foodcourtChecks;

        public IFoodcourtCheckRepository FoodcourtChecks =>
            foodcourtChecks ??= new FoodcourtCheckRepository(context);

        private IFoodProductsRepository foodProducts;

        public IFoodProductsRepository FoodProducts =>
            foodProducts ??= new FoodProductsRepository(context);

        private IGenreRepository genres;

        public IGenreRepository Genres =>
            genres ??= new GenreRepository(context);

        private IMovieGenreRepository movieGenres;

        public IMovieGenreRepository MovieGenres =>
            movieGenres ??= new MovieGenreRepository(context);

        private IMovieRepository movies;

        public IMovieRepository Movies =>
            movies ??= new MovieRepository(context);

        private IPositionRepository positions;

        public IPositionRepository Positions =>
            positions ??= new PositionRepository(context);

        private IShowingRepository showings;

        public IShowingRepository Showings =>
            showings ??= new ShowingRepository(context);

        private ITechnologyRepository technologies;

        public ITechnologyRepository Technologies =>
            technologies ??= new TechnologyRepository(context);

        private ITicketCheckRepository ticketChecks;

        public ITicketCheckRepository TicketChecks =>
            ticketChecks ??= new TicketCheckRepository(context);

        private ITicketRepository tickets;

        public ITicketRepository Tickets =>
            tickets ??= new TicketRepository(context);

        private IWorkerRepository workers;

        public IWorkerRepository Workers =>
            workers ??= new WorkerRepository(context);

        public void Dispose()
        {
            if (context != null)
                context.Dispose();
            context = null;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }

}
