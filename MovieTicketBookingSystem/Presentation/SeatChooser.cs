using System;
using MovieTicketBookingSystem.Controller.Contract;
using MovieTicketBookingSystem.Model;
using MovieTicketBookingSystem.Presentation.Contract;
using MovieTicketBookingSystem.Presentation.Util;

namespace MovieTicketBookingSystem.Presentation
{
	public class SeatChooser : ISeatChooser
	{
        protected ISeatDataController Controller;

        public SeatChooser(ISeatDataController controller)
        {
            Controller = controller;
        }

        public Ticket? Choose(Show show,int theatreId,int movieId)
        {
            DisplayDetails(show);
            if (show.Seats.Count == 0) return null;
            while (true)
            {
                try
                {
                    string input = InputValidator.GetInstance().GetValidKeySeperatedValues("Please select you choice", ',').ToUpper();
                    if (input == "--Q") break;
                    Ticket? ticket = Controller.BookSeats(show, input, theatreId, movieId);
                    if (ticket == null) {
                        Console.WriteLine("Invalid Input or Seat selected was already booked");
                        continue;
                    }
                    return ticket;
                }
                catch
                {
                    //Console.WriteLine(e.ToString());
                    Console.WriteLine("\nPlease Enter Valid Input");
                }
            }
            return null;
        }

        private void DisplayDetails(Show show)
        {
            Console.WriteLine($"\nPlease select the seating for {show.Time:hh\\:mm\\ tt} show\n");
            int numOfSeatsInRow = show.Seats[show.Seats.Count - 1].SNo;
            char endOfRow = show.Seats[show.Seats.Count - 1].Row;
            Console.Write("   ");
            for (int j = 1; j <= numOfSeatsInRow; j++)
            {
                Console.Write(j+"  ");
            }
            Console.WriteLine();
            int index = 0;
            for (char i = 'A'; i <= endOfRow; i++)
            {
                Console.Write($"{i}  ");
                for (int j = 1; j <= numOfSeatsInRow; j++)
                {
                    Seat currentSeat = show.Seats[index++];
                    Console.Write(currentSeat.Status == Enum.SeatStatus.Available ? "□  " : "■  ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nAvailable -> □  Booked -> ■");
            Console.WriteLine($"\nplease enter --q to go back");
            Console.WriteLine("Please enter the input in this format : B2,B3,B4");
        }
    }
}

