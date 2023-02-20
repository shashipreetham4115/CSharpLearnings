using System;
using MovieTicketBookingSystem.Model;
using MovieTicketBookingSystem.Presentation.Contract;
using MovieTicketBookingSystem.Presentation.Util;
using MovieTicketBookingSystem.Controller.Contract;

namespace MovieTicketBookingSystem.Presentation
{
	public class TheatreChooser : ITheatreChooser
    {
        protected ITheatreDataHandler Handler;

        public TheatreChooser(ITheatreDataHandler Handler)
        {
            this.Handler = Handler;
        }

        public Theatre? Choose(string city)
        {
            var theatres = Handler.GetTheatres(city);
            DisplayDetails(city, theatres);
            if (theatres.Count == 0) return null;
            while (true)
            {
                try
                {
                    int input = InputValidator.GetInstance().GetValidInt("Please select you choice");
                    if (input == -1 || input == theatres.Count+1) break;
                    return input switch
                    {
                        int n when (n >= 1 && n <= theatres.Count) => theatres[input-1],
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

        private void DisplayDetails(string city, List<Theatre> theatres)
        {
            if (theatres.Count > 0)
            {
                Console.WriteLine($"\nPlease select a theatre at {city}\n");
                for (int i = 0; i < theatres.Count; i++)
                {
                    Console.WriteLine($"{i + 1}) {theatres[i].Name}");
                };
                Console.WriteLine($"{theatres.Count+1}) Exit");
            }
            else
            {
                Console.WriteLine($"No theatre found at {city} \n");
            }
        }
    }
}

