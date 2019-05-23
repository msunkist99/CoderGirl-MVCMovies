using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.Models
{
    public interface IModel
    {
        // public by default
        int Id { get; set; }
    }
}
