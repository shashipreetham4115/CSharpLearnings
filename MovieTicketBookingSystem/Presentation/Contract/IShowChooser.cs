using System;
using MovieTicketBookingSystem.Model;

namespace MovieTicketBookingSystem.Presentation.Contract
{
    public interface IShowChooser
    {
        public Show? Choose(Movie movie, DateTime date);
    }
}

