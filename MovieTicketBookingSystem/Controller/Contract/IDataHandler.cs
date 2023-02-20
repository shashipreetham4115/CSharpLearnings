using System;
using MovieTicketBookingSystem.Model;

namespace MovieTicketBookingSystem.Controller.Contract
{
	public interface IDataHandler
	{
		public List<Theatre> GetTheatres();
	}
}

