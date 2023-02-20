using System;
using MovieTicketBookingSystem.Controller.Contract;
using MovieTicketBookingSystem.Model;

namespace MovieTicketBookingSystem.Controller
{
	public class MovieDataController : IMovieDataController
    {
        protected IDataHandler DataHandler;

        public MovieDataController(IDataHandler dataHandler)
        {
            DataHandler = dataHandler;
        }

        public List<Movie> GetMovies(Theatre theatre, DateTime bookingDate)
        {
            List<Movie>? movies = null;
            theatre?.Movies.TryGetValue(bookingDate, out movies);
            return movies ?? new List<Movie>();
        }
    }
}

