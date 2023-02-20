using HandCricketGame.Controller.Contract;
using HandCricketGame.Model;
using HandCricketGame.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandCricketGame.Controller
{
    internal class NewGameController : INewGameController
    {
        protected IDataController DataController;
        protected IResetHandler MatchHandler;
        protected UniqueIdGenerator UniqueIdGenerator = UniqueIdGenerator.GetInstance();
        public NewGameController(IDataController dataController, IResetHandler matchHandler)
        {
            DataController = dataController;
            MatchHandler = matchHandler;
        }

        public void StartMatch()
        {
            MatchHandler.Reset(CreateMatch());
        }

        private List<Player> AddPlayers()
        {
            var players = DataController.GetAllPlayers();
            var player1 = GetRandomPlayer(players);
            var player2 = GetRandomPlayer(players);
            while (player1.Id == player2.Id)
            {
                player2 = GetRandomPlayer(players);
            }
            return new List<Player> { player1, player2 };
        }

        private Player GetRandomPlayer(List<Player> players)
        {
            int randomIndex = new Random().Next(players.Count);
            return players[randomIndex];
        }

        private Match CreateMatch()
        {
            var match = new Match(UniqueIdGenerator.GetUniqueId(), DateTime.Now);
            match.Players.AddRange(AddPlayers());
            DataController.AddMatch(match);
            return match;
        }
    }
}
