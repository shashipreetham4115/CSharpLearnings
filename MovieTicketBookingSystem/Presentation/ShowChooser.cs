using System;
using System.Globalization;
using MovieTicketBookingSystem.Model;
using MovieTicketBookingSystem.Presentation.Contract;
using MovieTicketBookingSystem.Presentation.Util;

namespace MovieTicketBookingSystem.Presentation
{
	public class ShowChooser : IShowChooser
	{
        public Show? Choose(Movie movie, DateTime bookingDate)
        {
            var shows = movie.Shows;
            DisplayDetails(shows, bookingDate, movie.Name);
            if (shows.Count == 0) return null;
            while (true)
            {
                try
                {
                    int input = InputValidator.GetInstance().GetValidInt("Please select you choice");
                    if (input == -1 || input == shows.Count + 1) break;
                    return input switch
                    {
                        int n when (n >= 1 && n <= shows.Count) => shows[input-1],
                        _ => throw new InvalidDataException()
                    };
                }
                catch
                {
                    //Console.WriteLine(e.ToString());
                    Console.WriteLine("\nPlease Enter Valid Input");
                }
            }
            return null;
        }

        private void DisplayDetails(List<Show> shows, DateTime bookingDate, string movie)
        {
            if (shows.Count > 0)
            {
                Console.WriteLine($"\nPlease select show timings for {movie} movie on {bookingDate:dd/MM/yyyy} \n");
                for (int i = 0; i < shows.Count; i++)
                {
                    Console.WriteLine($"{i + 1}) {shows[i].Time.ToString("t",CultureInfo.CreateSpecificCulture("en-us"))}   [{shows[i].Status}]");
                };
                Console.WriteLine($"{shows.Count + 1}) Back");
            }
            else
            {
                Console.WriteLine($"No shows found on {bookingDate} \n");
            }
        }
    }
}

