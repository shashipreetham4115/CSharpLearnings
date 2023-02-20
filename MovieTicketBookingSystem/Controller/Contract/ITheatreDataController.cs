using System;
using MovieTicketBookingSystem.Model;

namespace MovieTicketBookingSystem.Controller.Contract
{
	public interface ITheatreDataHandler
	{
		public List<Theatre> GetTheatres(string city);
	}
}

