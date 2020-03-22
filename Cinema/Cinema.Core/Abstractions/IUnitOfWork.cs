using Cinema.Core.Abstractions.Repositories;
using System;

namespace Cinema.Core.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        ICheckRepository Checks { get; }
        ICinemaHallRepository CinemaHalls { get; }
        ICinemaLocationRepository CinemaLocations { get; }
        ICityRepository Cities { get; }
        ICountryOfOriginRepository CountryOfOrigins { get; }
        IDirectorRepository Directors { get; }
        IFoodAmountRepository FoodAmounts { get; }
        IFoodcourtCheckProductRepository FoodcourtCheckProducts { get; }
        IFoodcourtCheckRepository FoodcourtChecks { get; }
        IFoodProductsRepository FoodProducts { get; }
        IGenreRepository Genres { get; }
        IMovieGenreRepository MovieGenres { get; }
        IMovieRepository Movies { get; }
        IPositionRepository Positions { get; }
        IShowingRepository Showings { get; }
        ITechnologyRepository Technologies { get; }
        ITicketCheckRepository TicketChecks { get; }
        ITicketRepository Tickets { get; }
        IWorkerRepository Workers { get; }
        void SaveChanges();
    }

}
