using System.Collections.Generic;

namespace Cinema.Core.Entities
{
    public class Position: IEntity<int>
    {
        public int Id { get; set; }
        public string PositionName { get; set; }
        public List<Worker> Workers { get; set; }
    }
}
