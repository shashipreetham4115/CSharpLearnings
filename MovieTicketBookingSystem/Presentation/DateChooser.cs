using System;
using MovieTicketBookingSystem.Model;
using MovieTicketBookingSystem.Presentation.Contract;
using MovieTicketBookingSystem.Presentation.Util;

namespace MovieTicketBookingSystem.Presentation
{
	public class DateChooser : IDateChooser
	{
        private int NoofDays = 0;

        public DateTime? Choose(DateTime startDate, DateTime endDate)
        {
            DisplayDetails(startDate, endDate);
            while (true)
            {
                try
                {
                    int input = InputValidator.GetInstance().GetValidInt("Please select you choice");
                    if (input == -1 || input == NoofDays) break;
                    return input switch
                    {
                        int n when (n >= 1 && n < NoofDays) => startDate.AddDays(input-1),
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

        private void DisplayDetails(DateTime startDate, DateTime endDate)
        {
            NoofDays = 0;
            Console.WriteLine($"\nPlease select your date for movie\n");
            while(startDate.AddDays(NoofDays) <= endDate)
            {
                Console.WriteLine($"{NoofDays + 1}) {startDate.AddDays(NoofDays++):dd/MM/yyyy}");
            }
            Console.WriteLine($"{++NoofDays}) Back");
        }
    }
}

