using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.GlobalException
{
    public class MovieListFull : Exception
    {
        public MovieListFull(string message) : base(message) { }
    }
}
