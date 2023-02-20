using System;
using MovieTicketBookingSystem.Model;

namespace MovieTicketBookingSystem.Presentation.Contract
{
    public interface IRebookingChooser
    {
        public bool Choose(Ticket ticket, Theatre theatre, Movie movie);
    }
}

