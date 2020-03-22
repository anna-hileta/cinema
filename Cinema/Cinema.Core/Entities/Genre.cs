using System.Collections.Generic;

namespace Cinema.Core.Entities
{
    public class Genre: IEntity<int>
    {
        public int Id { get; set; }
        public string GenreName { get; set; }
        public List<MovieGenre> MovieGenres { get; set; }
    }
}
