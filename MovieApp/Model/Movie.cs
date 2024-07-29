using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Model
{
    public class Movie
    {
        public string MovieId { get; set; }
        public string MovieName { get; set; }
        public string MovieCategory {  get; set; }
        public int MovieYear { get; set; }
        public static int MovieCount { get; set; }

        public Movie(string movieId, string movieName, string movieCategory, int movieYear) 
        { 
            MovieId = movieId;
            MovieName = movieName;
            MovieCategory = movieCategory;
            MovieYear = movieYear;
            MovieCount = MovieCount +1;
        }
    }
}
