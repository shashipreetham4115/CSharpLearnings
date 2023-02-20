using HandCricketGame.Controller.Contract;
using HandCricketGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandCricketGame.Controller
{
    public class WinnerController : IWinnerController
    {
        protected IDataController DataController;
        public WinnerController(IDataController dataController) 
        {
            DataController = dataController;    
        }

        public Player GetTossResult(List<Player> players)
        {
            var player = GetRandomPlayer(players);
            DataController.UpdateMatchTossWinnerId(player.Id);
            return player;
        }

        private Player GetRandomPlayer(List<Player> players)
        {
            int randomIndex = new Random().Next(players.Count);
            return players[randomIndex];
        }

        public Player? GetWinnerOfTheMatch(Match match)
        {
            Player? winner = null;
            if (match.WinnerId == "")
            {
                int player1WinCount = 0;
                int drawCount = 0;
                string player1 = match.Players[0].Id;
                match.Rounds.ForEach(round =>
                {
                    if (round.WinnerId == player1) player1WinCount++;
                    else if (round.WinnerId == "") drawCount++;
                });
                int player2WinCount = 3 - player1WinCount - drawCount;
                if (player1WinCount > player2WinCount)
                    winner = match.Players[0];
                else if (player2WinCount > player1WinCount) winner = match.Players[1];
                DataController.UpdateMatchWinnerId(winner?.Id ?? "tie");
            }
            else
            {
                winner = match.Players.Find(player => player.Id == match.WinnerId);
            }
            return winner;
        }

        public string? GetWinnerOfTheRound(Round round)
        {
            string? winner = "";
            if (round.WinnerId == "")
            {
                var firstInning = round.Innings.First();
                var secondInning = round.Innings.Last(); 
                var firstInningScore = GetInningScore(round.Innings.First());
                var secondInningScore = GetInningScore(round.Innings.Last());
                if (firstInningScore > secondInningScore)
                {
                    winner = firstInning.StrikerId;
                }
                else if (secondInningScore > firstInningScore)
                {
                    winner = secondInning.StrikerId;
                }
                DataController.UpdateRoundWinnerId(winner == ""? "tie" : winner);
            }
            else
            {
                winner = round.WinnerId;
            }
            return winner;
        }

        private int GetInningScore(Inning inning)
        {
            return inning.Deliveries.Sum(delivery => delivery.StrikerScore);
        }
    }
}
