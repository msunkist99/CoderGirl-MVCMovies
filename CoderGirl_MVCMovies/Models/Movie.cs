using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.Models
{
    public class Movie
    {
        public int Id { set; get; }
        public string Name { get; set; }
        public int Year { get; set; }

        public List<int> MovieRatings { get; set; }
        public int DirectorId { get; set; }
        public string DirectorName { get; set; }
        //public Director DirectorObject { get; set; }

        // below would help if a movie could have one to many directors
        //public List<string> DirectorIds { get; set; }
        //public List<Director> Directors { get; set; }

        public decimal AverageRating { get; set; }
        public int NumberOfRatings { get; set; }

    }
}
