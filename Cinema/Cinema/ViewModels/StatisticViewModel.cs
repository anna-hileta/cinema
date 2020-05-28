using Cinema.Core.Abstractions.Services;
using Cinema.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.ViewModels
{
    public class StatiticViewModel
    {
        public int MaxCount { get; set; }
        public int MinCount { get; set; }
        public DateTime MinDate { get; set; }
        public DateTime MaxDate { get; set; }
        public List<DateTime> Day { get; set; }
        public List<int> ticksperDay { get; set; }
    }
}
