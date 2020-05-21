using Cinema.Core.Abstractions.Services;
using Cinema.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.ViewModels
{
    public class GenreSelectionViewModel
    {
        public bool IsSelected { get; set; }
        public int GenreId { get; set; }
        public string GenreName { get; set; }
    }
}
