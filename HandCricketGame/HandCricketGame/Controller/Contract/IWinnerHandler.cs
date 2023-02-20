using HandCricketGame.Model;

namespace HandCricketGame.Controller.Contract
{
    public interface IWinnerHandler
    {
        public Player? GetWinnerOfTheMatch();
        public Player? GetWinnerOfTheRound(int roundNo);
        public Player GetTossResult();
    }
}