using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.Models
{
    public class Movie : IModel
    {
        // Id from the IModel interface
        public int Id { set; get; }

        public string Name { get; set; }
        public string DirectorName { get; set; }
        public int Year { get; set; }
        public List<int> Ratings { get; set; }
        public int DirectorId { get; set; }
        public decimal RatingAverage { get; set; }
        public int RatingCount { get; set; }
    }
}
