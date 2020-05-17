using Cinema.Core.Entities;
using Cinema.DAL.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Cinema.DAL
{
    public class CinemaContext : IdentityDbContext<Worker, IdentityRole<Guid>, Guid>
    {
        public DbSet<Check> Checks { get; set; }
        public DbSet<CinemaHall> CinemaHalls { get; set; }
        public DbSet<CinemaLocation> CinemaLocations { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CountryOfOrigin> CountryOfOrigins { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<FoodAmount> FoodAmounts { get; set; }
        public DbSet<FoodcourtCheck> FoodcourtChecks { get; set; }
        public DbSet<FoodcourtCheckProduct> FoodcourtCheckProducts { get; set; }
        public DbSet<FoodProducts> FoodProducts { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Showing> Showings { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketCheck> TicketChecks { get; set; }

        public CinemaContext(DbContextOptions<CinemaContext> options) : base(options) {
            Database.SetCommandTimeout(9000);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new MovieConfiguration());
            builder.ApplyConfiguration(new CheckConfiguration());
            builder.ApplyConfiguration(new CinemaHallConfiguration());
            builder.ApplyConfiguration(new CinemaLocationConfiguration());
            builder.ApplyConfiguration(new CityConfiguration());
            builder.ApplyConfiguration(new CountryOfOriginConfiguration());
            builder.ApplyConfiguration(new DirectorConfiguration());
            builder.ApplyConfiguration(new FoodAmountConfiguration());
            builder.ApplyConfiguration(new FoodcourtCheckConfiguration());
            builder.ApplyConfiguration(new FoodcourtCheckProductConfiguration());
            builder.ApplyConfiguration(new FoodProductsConfiguration());
            builder.ApplyConfiguration(new GenreConfiguration());
            builder.ApplyConfiguration(new PositionConfiguration());
            builder.ApplyConfiguration(new TechnologyConfiguration());
            builder.ApplyConfiguration(new TicketConfiguration());
            builder.ApplyConfiguration(new WorkerConfiguration());
        }
    }

}
