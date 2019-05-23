using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.Models
{
    public class MovieRating : IModel
    {
        // Id from the IModel interface
        public int Id { get; set; }

        public string MovieName { get; set; }
        public int Rating { get; set; }
        public int MovieId { get; set; }
    }
}
