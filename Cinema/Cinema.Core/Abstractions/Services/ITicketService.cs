using Cinema.Core.Entities;
using System.Collections.Generic;

namespace Cinema.Core.Abstractions.Services
{
    public interface ITicketService
    {
        public List<Ticket> Get();

        public Ticket GetById(int id);

        public Ticket Add(Ticket ticket);

        public Ticket Update(Ticket ticket);

        public void Delete(int id);
    }

}
