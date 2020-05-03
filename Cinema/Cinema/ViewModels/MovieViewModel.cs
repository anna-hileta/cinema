﻿using Cinema.Core.Abstractions.Services;
using Cinema.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.ViewModels
{
    public class MovieViewModel
    {
        public List<Movie> movies { get; set; }
        public List<Genre> genres { get; set; }
        public Movie movie { get; set; }
        public List<int> genre { get; set; }
    }
}
