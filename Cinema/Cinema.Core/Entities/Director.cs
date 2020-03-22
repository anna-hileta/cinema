using System.Collections.Generic;

namespace Cinema.Core.Entities
{
    public class Director: IEntity<int>
    {
        public int Id { get; set; }
        public string DirectorName { get; set; }
        public List<Movie> Movies { get; set; }

    }
}
