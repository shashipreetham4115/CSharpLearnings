using System;
using MovieTicketBookingSystem.Model;
using MovieTicketBookingSystem.Presentation.Contract;
using MovieTicketBookingSystem.Presentation.Util;

namespace MovieTicketBookingSystem.Presentation
{
	public class RebookingChooser : IRebookingChooser
    {
        public bool Choose(Ticket ticket, Theatre theatre, Movie movie)
        {
            DisplayPreviousBooking(ticket, theatre, movie);
            while (true)
            {
                try
                {
                    int input = InputValidator.GetInstance().GetValidInt("Please select you choice");
                    if (input == -1) break;
                    return input switch
                    {
                        1 => true,
                        2 => false,
                        _ => throw new InvalidDataException()
                    };
                }
                catch
                {
                    //Console.WriteLine(e.ToString());
                    Console.WriteLine("\nPlease Enter Valid Input");
                }
            }
            return false;
        }

        public void DisplayPreviousBooking(Ticket ticket, Theatre theatre, Movie movie)
        {
            Console.WriteLine("\n-----------------------------------------");
            Console.WriteLine("Ticket Booked Successfully");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"Ticket Id   : {ticket.Id}");
            Console.WriteLine($"Movie       : {movie.Name}");
            Console.WriteLine($"Theatre     : {theatre.Name}");
            Console.WriteLine($"Show Timing : {ticket.Date:dd MMM yyyy hh:mm tt}");
            Console.WriteLine($"Seats       : {string.Join(", ",ticket.SeatNos)}");
            Console.WriteLine("-----------------------------------------\n");
            Console.WriteLine("Do you want to another time\n1) Yes\n2) No\n");
        }
    }
}

