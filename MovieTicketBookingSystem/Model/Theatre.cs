using MovieTicketBookingSystem.Util;
using System;
using System.Collections.Generic;

namespace MovieTicketBookingSystem.Model
{
    [Serializable]
    public class Theatre
	{
        public int Id { get; private set; }
        public string Name;
        public string Location;
        public Dictionary<DateTime, List<Movie>> Movies;
        public bool isOpen = true;

        public Theatre(int id,string name, string location, Dictionary<DateTime, List<Movie>> movies)
		{
            Name = name;
            Location = location;
            Movies = movies;
            Id = id;
		}

        public override string ToString()
        {
            return $"\nId : {Id}, Name : {Name}, Location : {Location}, Dictionary<DateTime, List<Movie>> : {string.Join(", ", Movies.Select(x => x.Key.ToString("dd MM yyyy hh:mm tt") + ": " + string.Join(", ",x.Value)))}\n";
        }
    }
}

