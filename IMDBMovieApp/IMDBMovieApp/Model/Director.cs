using System;
using System.Collections.Generic;

namespace IMDBMovieApp.Model
{
    public partial class Director
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string? Bio { get; set; }
    }
}
