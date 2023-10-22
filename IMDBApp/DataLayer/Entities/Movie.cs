using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public int DirectorId { get; set; }
        public string Title { get; set; }
        public string? TagLine { get; set; }
        public int Year { get; set; }
        public double IMDBRate { get; set; }
        public string Description { get; set; }
        public string? Poster { get; set; }
        public DateTime CreateDate { get; set; }

        public Director Director { get; set; }

    }
}
