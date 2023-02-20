using System;
using MovieTicketBookingSystem.Model;

namespace MovieTicketBookingSystem.Controller.Contract
{
    public interface IMovieDataController
    {
        public List<Movie> GetMovies(Theatre theatre, DateTime bookingDate);
    }
}

