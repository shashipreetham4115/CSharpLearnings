using MovieTicketBookingSystem.Util;
using System;
namespace MovieTicketBookingSystem.Model
{
    [Serializable]
    public class Ticket
	{
        public int Id { get; private set; }
        public int ShowId;
		public int TheaterId;
		public int MovieId;
		public DateTime Date;
		public List<string> SeatNos;

        public Ticket(int id, int showId, int theaterId, int movieId, DateTime date, List<string> seatNos)
		{
			ShowId = showId;
			TheaterId = theaterId;
			MovieId = movieId;
			SeatNos = seatNos;
			Date = date;
			Id = id;
        }
	}
}

