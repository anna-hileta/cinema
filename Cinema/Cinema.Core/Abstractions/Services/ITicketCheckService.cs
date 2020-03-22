using Cinema.Core.Entities;
using System.Collections.Generic;

namespace Cinema.Core.Abstractions.Services
{
    public interface ITicketCheckService
    {
        public List<TicketCheck> Get();

        public TicketCheck GetById(int id);

        public TicketCheck Add(TicketCheck ticketCheck);

        public TicketCheck Update(TicketCheck ticketCheck);

        public void Delete(int id);
    }

}
