using HandCricketGame.Model;

namespace HandCricketGame.Controller.Contract
{
    public interface IRecentGameController
    {
        public List<Match> GetAllMatches();
        public void SelectMatch(Match match);
    }
}