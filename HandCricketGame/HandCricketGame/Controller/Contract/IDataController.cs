using HandCricketGame.Model;
using HandCricketGame.Util;

namespace HandCricketGame.Controller.Contract
{
    public interface IDataController
    {
        public List<Player> GetAllPlayers();
        public List<Match> GetAllMatches();

        public void AddMatch(Match match);
        public void AddRound(Round round);
        public void AddInning(Inning inning);
        public void AddDelivery(Delivery delivery);

        public void UpdateRoundWinnerId(string winnerId);
        public void UpdateMatchTossWinnerId(string winnerId);
        public void UpdateMatchWinnerId(string winnerId);

    }
}