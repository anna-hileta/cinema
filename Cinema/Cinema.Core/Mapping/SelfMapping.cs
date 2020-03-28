using AutoMapper;
using Cinema.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Core.Mapping
{
    public class SelfMapping : Profile
    {
        public SelfMapping()
        {
            CreateMap<City, City>();
            CreateMap<Check, Check>();
            CreateMap<CinemaHall, CinemaHall>();
            CreateMap<CinemaLocation, CinemaLocation>();
            CreateMap<CountryOfOrigin, CountryOfOrigin>();
            CreateMap<Director, Director>();
            CreateMap<FoodAmount, FoodAmount>();
            CreateMap<FoodcourtCheck, FoodcourtCheck>();
            CreateMap<FoodcourtCheckProduct, FoodcourtCheckProduct>();
            CreateMap<FoodProducts, FoodProducts>();
            CreateMap<Genre, Genre>();
            CreateMap<Movie, Movie>();
            CreateMap<MovieGenre, MovieGenre>();
            CreateMap<Position, Position>();
            CreateMap<Showing, Showing>();
            CreateMap<Technology, Technology>();
            CreateMap<Ticket, Ticket>();
            CreateMap<TicketCheck, TicketCheck>();
            CreateMap<Worker, Worker>();
        }
    }

}
