using System;
using System.Collections.Generic;

namespace IMDBMovieApp.Model
{
    public partial class Genre
    {
        public Genre()
        {
            MovieGenres = new HashSet<MovieGenre>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public virtual ICollection<MovieGenre> MovieGenres { get; set; }
    }
}
