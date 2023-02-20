using System;
using System.Xml.Linq;
using MovieTicketBookingSystem.Enum;
using MovieTicketBookingSystem.Util;

namespace MovieTicketBookingSystem.Model
{
    [Serializable]
    public class Show
	{
        public int Id { get; private set; }
        public int Screen;
        public DateTime Time { get; private set; }
        public List<Seat> Seats { get; private set; }
        public int AvailableTickets;
        public ShowStatus Status;

        public Show(int id, int screen, DateTime time, List<Seat> seats, int availableTickets, ShowStatus status = ShowStatus.Available)
		{
            Screen = screen;
            Time = time;
            Seats = seats;
            AvailableTickets = availableTickets;
            Status = status;
            Id = id;
		}

        public override string ToString()
        {
            return $"\nId : {Id}, Screen : {Screen}, Time : {Time:dd MM yyyy hh:mm tt}, AvailableTickets : {AvailableTickets}, ShowStatus : {Status}";
        }
    }
}

