using Cinema.Core.Abstractions.Services;
using Cinema.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.ViewModels
{
    public class ShowingViewModel
    {
        private readonly IShowingService service;
        public Showing showings { get; set; }
    }
}
