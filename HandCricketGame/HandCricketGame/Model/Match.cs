using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandCricketGame.Model
{
    public class Match
    {
        public string Id { get; private set; }
        public DateTime Date;
        public string WinnerId;
        public string TossWinnerId;
        public List<Round> Rounds { get; private set; } = new List<Round>(3);
        public List<Player> Players { get; private set; } = new List<Player>(2);

        public Match(string id, DateTime date)
        {
            Id = id;
            Date = date;
            TossWinnerId = "";
            WinnerId = "";
        }

        public Match(string id, DateTime date, string winnerId, string tossWinnerId) : this(id, date)
        {
            WinnerId = winnerId;
            TossWinnerId = tossWinnerId;
        }

    }
}
