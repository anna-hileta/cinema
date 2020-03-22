using Cinema.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.DAL
{
    public class CinemaContext : DbContext
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
        public DbSet<Worker> Workers { get; set; }

        public CinemaContext(DbContextOptions<CinemaContext> options) : base(options) { }
    }

}
