using Cinema.Core.Abstractions.Services;
using Cinema.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.ViewModels
{
    public class EditWorkerViewModel
    {
        public Worker worker { get; set; }
        public List<Position> positions;
        public bool isCorrect { get; set; }
    }
}
