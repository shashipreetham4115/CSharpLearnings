using System;
using MovieTicketBookingSystem.Model;

namespace MovieTicketBookingSystem.Presentation.Contract
{
    public interface IMovieChooser
    {
        public Movie? Choose(Theatre theatre, DateTime date);
    }
}

