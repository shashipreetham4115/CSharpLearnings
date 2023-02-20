using HandCricketGame.Controller.Contract;
using HandCricketGame.Model;
using HandCricketGame.Util;

namespace HandCricketGame.Controller
{
    public class MatchController : IRoundHandler, IWinnerHandler, IResetHandler
    {
        protected Match _Match;
        protected IDataController DataController;
        protected IGestureController GestureRoundController;
        protected IWinnerController WinnerController;
        protected UniqueIdGenerator UniqueIdGenerator;
        protected Random random = new Random();

        public MatchController(IDataController dataController, IGestureController gestureRoundController, IWinnerController winnerController) 
        {
            GestureRoundController= gestureRoundController;
            DataController= dataController;
            WinnerController= winnerController; 
            UniqueIdGenerator = UniqueIdGenerator.GetInstance();
        }

        public Round GetRound(int currentRound)
        {
            if (_Match.Rounds.Count < currentRound+1 && (currentRound >= -1 || currentRound <= 1))
            {
                var round = new Round(UniqueIdGenerator.GetUniqueId(), _Match.Id);
                round.Players = _Match.Players;
                DataController.AddRound(round);
            }
            return _Match.Rounds[currentRound];
        }

        public Inning GetInning(int currentRound, int currentInning) 
        {
            var round = _Match.Rounds[currentRound];
            if (round.Innings.Count < currentInning + 1 && (currentInning >= -1 || currentInning <= 1))
            {
                var strikerId = GetStrikerId(currentRound,currentInning);
                var inning = new Inning(UniqueIdGenerator.GetUniqueId(), round.Id, strikerId);
                DataController.AddInning(inning);
            }
            return round.Innings[currentInning];
        }

        private string GetStrikerId(int currentRound, int currentInning)
        {
            var strikerId = _Match.TossWinnerId;
            var bowlerId = _Match.Players.Find(player => player.Id != strikerId)!.Id;
            if ((currentInning % 2 != 0 || currentRound % 2 != 0) && !(currentInning % 2 != 0 && currentRound % 2 != 0))
            {
                strikerId = bowlerId;
            }
            return strikerId;
        }

        public IEnumerable<Delivery> GetGestures(int currentRound, int currentInning)
        {
            var round = _Match.Rounds[currentRound];
            return GestureRoundController.GetGestures(round, currentRound, currentInning);
        }

        public Player GetTossResult()
        {
           return WinnerController.GetTossResult(_Match.Players);
        }

        public Player? GetWinnerOfTheMatch()
        {
            return WinnerController.GetWinnerOfTheMatch(_Match);
        }

        public Player? GetWinnerOfTheRound(int roundNo)
        {
            var round = _Match.Rounds[roundNo];
            return _Match.Players.Find(player => player.Id == WinnerController.GetWinnerOfTheRound(round));
        }

        public void Reset(Match match)
        {
            _Match = match;
        }
    }
}
