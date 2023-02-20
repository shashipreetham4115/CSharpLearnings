using System;
using MovieTicketBookingSystem.Controller.Contract;
using MovieTicketBookingSystem.Model;
using MovieTicketBookingSystem.Util;

namespace MovieTicketBookingSystem.Controller
{
	public class SeatDataController : ISeatDataController
	{
        public Ticket? BookSeats(Show show, string seatNos, int theatreId, int movieId)
        {
            var seatNoList = seatNos.Split(",").ToList();
            var seats = show.Seats.FindAll(seat => seatNoList.Contains($"{seat.Row}{seat.SNo}"));
            if (CheckIfSeatsAlreadyBooked(seats, seatNoList))
            {
                seats.ForEach(seat => seat.Status = Enum.SeatStatus.Booked);
                show.AvailableTickets -= seats.Count;
                float availabilityPercentage = (float)show.AvailableTickets / show.Seats.Count * 100;
                if (availabilityPercentage <= 0f)
                {
                    show.Status = Enum.ShowStatus.NoSeats;
                }else if(availabilityPercentage <= 30f)
                {
                    show.Status = Enum.ShowStatus.LimitedSeats;
                }
                return new Ticket(UniqueIdGenerator.GetInstance().GetUniqueId(), show.Id, theatreId, movieId, show.Time, seatNoList);
            }
            return null;
        }

        private bool CheckIfSeatsAlreadyBooked(List<Seat> seats, List<string> seatNoList)
        {
            return seats.Count > 0 && seats.Count == seatNoList.Count && seats.All(seat => seat.Status == Enum.SeatStatus.Available);
        }
    }
}

