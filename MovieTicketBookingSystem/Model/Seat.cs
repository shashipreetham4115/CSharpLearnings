using System;
using System.Xml.Linq;
using MovieTicketBookingSystem.Enum;

namespace MovieTicketBookingSystem.Model
{
    [Serializable]
    public class Seat
	{
        public int SNo { get; private set; }
		public char Row;
		public SeatStatus Status;

		public Seat(char row, int sNo, SeatStatus status = SeatStatus.Available)
		{
			Row = row;
			SNo = sNo;
			Status = status;
		}

        public override string ToString()
		{
			//return $"{{ SNo : {SNo}, Row : {Row}, SeatStatus : {Status}";
			return "";
        }
    }
}

