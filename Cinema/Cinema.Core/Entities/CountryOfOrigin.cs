using System.Collections.Generic;

namespace Cinema.Core.Entities
{
    public class CountryOfOrigin: IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }

    }
}
