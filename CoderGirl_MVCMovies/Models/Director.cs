using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.Models
{
    public class Director
    {
        private string lastFirstName;

        public int Id { get; set; }

        public string FirstName {
            get
            {
                return FirstName;
            }
            set
            {
                this.FirstName = value;
                lastFirstName = LastName + ", " + FirstName;
            }
        }

        public string LastName
        {
            get
            {
                return LastName;
            }
            set
            {
                this.LastName = value;
                lastFirstName = LastName + ", " + FirstName;
            }
        }

        public string LastFirstName {
            get
            {
                return lastFirstName;
            }
        }

        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
