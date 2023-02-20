using System;
using MovieTicketBookingSystem.Model;

namespace MovieTicketBookingSystem.Presentation.Contract
{
    public interface ISeatChooser
    {
        public Ticket? Choose(Show show, int theatreId, int movieId);
    }
}

