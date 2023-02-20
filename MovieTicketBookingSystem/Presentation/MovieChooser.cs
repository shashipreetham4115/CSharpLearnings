using System;
using MovieTicketBookingSystem.Controller.Contract;
using MovieTicketBookingSystem.Model;
using MovieTicketBookingSystem.Presentation.Contract;
using MovieTicketBookingSystem.Presentation.Util;

namespace MovieTicketBookingSystem.Presentation
{
	public class MovieChooser : IMovieChooser
	{
        protected IMovieDataController MovieDataController;

        public MovieChooser(IMovieDataController movieDataHandler)
		{
            MovieDataController = movieDataHandler;
		}

        public Movie? Choose(Theatre theatre, DateTime bookingDate)
        {
            var movies = MovieDataController.GetMovies(theatre, bookingDate);
            DisplayDetails(movies, bookingDate);
            if (movies.Count == 0) return null;
            while (true)
            {
                try
                {
                    int input = InputValidator.GetInstance().GetValidInt("Please select you choice");
                    if (input == -1 || input == movies.Count + 1) break;
                    return input switch
                    {
                        int n when (n >= 1 && n <= movies.Count) => movies[input-1],
                        _ => throw new InvalidDataException()
                    };
                }
                catch
                {
                    //Console.WriteLine(e.ToString());
                    Console.WriteLine("\nPlease Enter Valid Input");
                }
            }
            return null;
        }

        private void DisplayDetails(List<Movie> movies, DateTime bookingDate)
        {
            if (movies.Count > 0)
            {
                Console.WriteLine($"\nPlease select a movie on {bookingDate:dd/MM/yyyy} \n");
                for (int i = 0; i < movies.Count; i++)
                {
                    Console.WriteLine($"{i + 1}) {movies[i].Name}");
                };
                Console.WriteLine($"{movies.Count + 1}) Back");
            }
            else
            {
                Console.WriteLine($"No movie found on {bookingDate} \n");
            }
        }
    }
}

