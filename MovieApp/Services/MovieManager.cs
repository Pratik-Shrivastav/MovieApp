using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieApp.GlobalException;
using MovieApp.Model;

namespace MovieApp.Services
{
    public class MovieManager
    { 
        List<Movie> movies = new List<Movie>();
        Serialization serialization = new Serialization();
        public MovieManager() 
        {
            movies = serialization.DesrializeData();
        }
        public void AddMovie()
        {
            try
            {
                if (Movie.MovieCount >= 5)
                {
                    throw new MovieListFull("Movie List is full");
                }
                else
                {
                    Console.WriteLine("Enter the movie Name");
                    string movieName = Console.ReadLine();
                    Console.WriteLine("Enter movie Category");
                    string movieCategory = Console.ReadLine();
                    Console.WriteLine("Enter the Release Year");
                    int movieYear = int.Parse(Console.ReadLine());

                    string movieId = $"{movieName.Substring(0, 2)}"+$"{movieCategory.Substring(0, 2)}"+$"{movieYear % 100}";
                    Movie newMovie = new Movie(movieId, movieName, movieCategory, movieYear);
                    movies.Add(newMovie);

                    serialization.SerializeData(movies);
                }
            }
            catch (MovieListFull ex) 
            {
                Console.WriteLine(ex.Message);
            }
            

        }
        public void DisplayMovie()
        {
            try
            {
                if (Movie.MovieCount == 0)
                {
                    throw new EmptyMovieList("Movie List is Empty");
                }
                else
                {
                    foreach (Movie movie in movies) 
                    { 
                        Console.WriteLine($"The Movie Id is : {movie.MovieId}" +
                            $"\nThe Movie Name is: {movie.MovieName}" +
                            $"\nThe Movie Category is: {movie.MovieCategory}" +
                            $"\nThe Movie Relese year is: {movie.MovieYear}" +
                            $"" +
                            $"\n------------------------------" +
                            $"");
                    }
                }
            }
            catch (EmptyMovieList ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void RemoveMovie() 
        {
            try
            {
                if (Movie.MovieCount == 0)
                {
                    throw new EmptyMovieList("Movie List is Empty");
                }
                else
                {
                    Console.WriteLine("Enter the Id of the movie to be deleted");
                    string userInput = Console.ReadLine();
                    for (int i = 0; i < Movie.MovieCount; i++)
                    {
                        if (movies[i].MovieId == userInput)
                        {
                            movies.RemoveAt(i);
                            Movie.MovieCount--;
                            serialization.SerializeData(movies);
                            break;

                        }
                    }
                }
            }
            catch (EmptyMovieList ex) 
            { 
                Console.WriteLine(ex.Message);
            }
        }

        public void RemoveAll()
        {
            movies.Clear();
            Movie.MovieCount = 0;
            Console.WriteLine("Removed all Movies");
        }

    }
}
