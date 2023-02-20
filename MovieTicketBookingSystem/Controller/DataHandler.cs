using System;
using MovieTicketBookingSystem.Model;
using MovieTicketBookingSystem.Controller.Contract;

namespace MovieTicketBookingSystem.Controller
{
	public class DataHandler : IDataHandler
	{
		private List<Theatre> Theatres;

		public DataHandler(List<Theatre> theatres)
		{
			Theatres = theatres;
		}

		public List<Theatre> GetTheatres()
		{
			return Theatres;
		}

	}
}

