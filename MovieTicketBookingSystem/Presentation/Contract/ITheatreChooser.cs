using System;
using MovieTicketBookingSystem.Model;

namespace MovieTicketBookingSystem.Presentation.Contract
{
    public interface ITheatreChooser
    {
        public Theatre? Choose(string city);
    }
}

