using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.Models
{
    public class MovieRating
    {
        public int Id { set; get; }
        public string Movie { get; set; }
        public string Rating { get; set; }
    }
}
