using HandCricketGame.Model;
using HandCricketGame.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandCricketGame.Data.Contract
{
    public interface IDatabaseService
    {
        public List<Player> GetAllPlayers();

        public List<Match> GetAllMatches();

        public void InsertMatch(Match match);
        public void InsertRound(Round round);
        public void InsertInning(Inning inning);
        public void InsertDelivery(Delivery delivery);
        public void InsertPlayer(Player player);

        public void UpdateRoundWinnerId(string roundId, string winnerId);
        public void UpdateMatchTossWinnerId(string matchId, string winnerId); 
        public void UpdateMatchWinnerId(string matchId, string winnerId);
        public void UpdateInningScore(string inningId, int score);
    }
}
