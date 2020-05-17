using Cinema.Core.Entities;
using System.Collections.Generic;

namespace Cinema.Core.Abstractions.Services
{
    public interface IShowingService : IBasicService<Showing, int> {
        public Showing GetShowingInfo(int showingId);
        public List<Showing> GetShowingsInfo();
    }
}
