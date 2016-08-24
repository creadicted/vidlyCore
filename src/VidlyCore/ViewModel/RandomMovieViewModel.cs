using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VidlyCore.Models;

namespace VidlyCore.ViewModel
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }

        public List<Customer> Customers { get; set; }
    }
}
