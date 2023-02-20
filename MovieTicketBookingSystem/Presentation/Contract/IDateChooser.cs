using System;
namespace MovieTicketBookingSystem.Presentation.Contract
{
    public interface IDateChooser
    {
        public DateTime? Choose(DateTime startDate, DateTime endDate);
    }
}

