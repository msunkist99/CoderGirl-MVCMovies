using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.Models
{
    public class Director
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
 
        public string LastName { get; set; }

        public string LastFirstName {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }
    }
}
