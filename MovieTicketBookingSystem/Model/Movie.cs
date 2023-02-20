using MovieTicketBookingSystem.Util;
using System;
namespace MovieTicketBookingSystem.Model
{
	[Serializable]
	public class Movie
	{
		public int Id { get; private set; }
		public string Name;
		public List<Show> Shows;

		public Movie(int id, string name, List<Show> shows)
		{
			Name = name;
            Shows = shows;
			Id = id;
		}

        public override string ToString()
        {
			return $"\n{{ Name : {Name}, List<Show> : {string.Join(", ", Shows)}\n";
        }
    }
}

