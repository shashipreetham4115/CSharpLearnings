using System;
using MovieTicketBookingSystem.Model;
using MovieTicketBookingSystem.Controller.Contract;

namespace MovieTicketBookingSystem.Controller
{
	public class TheatreDataHandler : ITheatreDataHandler
	{
        protected IDataHandler DataHandler;

		public TheatreDataHandler(IDataHandler dataHandler)
		{
            DataHandler = dataHandler;
		}

        public List<Theatre> GetTheatres(string city)
        {
            var theatres = DataHandler.GetTheatres();
            return theatres.Where(theatre => theatre.Location.ToLower() == city.ToLower()).ToList();
        }
    }
}

