using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Core.DAL
{
    public class FoodDTO
    {
        public List<FoodAmountDTO> TicketIds { get; set; }
        public double Price { get; set; }
    }
}
