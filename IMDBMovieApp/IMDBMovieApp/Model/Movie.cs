using System;
using System.Collections.Generic;

namespace IMDBMovieApp.Model
{
    public partial class Movie
    {
        public Movie()
        {
            MovieGenres = new HashSet<MovieGenre>();
        }

        public int Id { get; set; }
        public int DirectorId { get; set; }
        public string Title { get; set; } = null!;
        public string? Tagline { get; set; }
        public int Year { get; set; }
        public double Imdbrate { get; set; }
        public string? Description { get; set; }
        public string? Poster { get; set; }
        public string Cast { get; set; } = null!;
        public DateTime CreateDate { get; set; }

        public virtual ICollection<MovieGenre> MovieGenres { get; set; }
    }
}
