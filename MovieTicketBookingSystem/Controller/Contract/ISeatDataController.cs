using System;
using MovieTicketBookingSystem.Model;

namespace MovieTicketBookingSystem.Controller.Contract
{
    public interface ISeatDataController
    {
        public Ticket? BookSeats(Show show, string seatNos, int theatreId, int movieId);
    }
}

