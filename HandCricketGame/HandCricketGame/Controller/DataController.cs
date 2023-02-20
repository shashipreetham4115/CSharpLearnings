using HandCricketGame.Controller.Contract;
using HandCricketGame.Data.Contract;
using HandCricketGame.Model;
using HandCricketGame.Util;
using System.Text;

namespace HandCricketGame.Controller
{
    public class DataController : IDataController
    {
        private List<Player> _Players;
        private List<Match> _Matches;
        private UniqueIdGenerator _UniqueIdGenerator = UniqueIdGenerator.GetInstance();
        private IDatabaseService _DatabaseService;

        public DataController(IDatabaseService databaseService) 
        {
            _DatabaseService = databaseService;
            _Players = new List<Player>();
            _Matches = new List<Match>();
            RefreshData();
        }

        public List<Player> GetAllPlayers()
        {
            return _Players;
        }

        public void RefreshData()
        {
            GetAllPlayersFromDB();
            GetAllMatchesFromDB();
        }

        private void GetAllPlayersFromDB()
        {
            _Players = _DatabaseService.GetAllPlayers();
            if (_Players.Count == 0)
            {
                List<Player> list = new List<Player>();
                list.Add(new Player(_UniqueIdGenerator.GetUniqueId(), "Shashi"));
                list.Add(new Player(_UniqueIdGenerator.GetUniqueId(), "Preetham"));
                list.Add(new Player(_UniqueIdGenerator.GetUniqueId(), "Reddy"));
                _Players.AddRange(list);
                _DatabaseService.InsertPlayer(list[0]);
                _DatabaseService.InsertPlayer(list[1]);
                _DatabaseService.InsertPlayer(list[2]);
            }
        }

        private void GetAllMatchesFromDB()
        {
            _Matches.Clear();
            _Matches.AddRange(_DatabaseService.GetAllMatches());    
        }

        public List<Match> GetAllMatches()
        {
           return _Matches;
        }

        public void AddMatch(Match match) 
        {
            _Matches.Add(match);
            _DatabaseService.InsertMatch(match);
        }

        public void AddRound(Round round) 
        {
            var rounds = _Matches.Last().Rounds;
            rounds.Add(round);
            _DatabaseService.InsertRound(round);
        }

        public void AddInning(Inning inning)
        {
            var rounds = _Matches.Last().Rounds;
            var innings = rounds.Last().Innings; 
            innings.Add(inning);
            _DatabaseService.InsertInning(inning);
        }

        public void AddDelivery(Delivery delivery)
        {
            var rounds = _Matches.Last().Rounds;
            var innings = rounds.Last().Innings;
            var deliveries = innings.Last().Deliveries;
            deliveries.Add(delivery);
            _DatabaseService.InsertDelivery(delivery);
        }

        public void UpdateRoundWinnerId(string winnerId)
        {
            var round = _Matches.Last().Rounds.Last();
            round.WinnerId = winnerId;
            _DatabaseService.UpdateRoundWinnerId(round.Id, winnerId);
        }

        public void UpdateMatchTossWinnerId(string winnerId)
        {
            var match = _Matches.Last();
            match.TossWinnerId = winnerId;
            _DatabaseService.UpdateMatchTossWinnerId(match.Id, winnerId);
        }

        public void UpdateMatchWinnerId(string winnerId)
        {
            var match = _Matches.Last();
            match.WinnerId = winnerId;
            _DatabaseService.UpdateMatchWinnerId(match.Id, winnerId);
        }
    }
}
