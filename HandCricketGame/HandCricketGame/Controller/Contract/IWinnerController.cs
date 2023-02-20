using HandCricketGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandCricketGame.Controller.Contract
{
    public interface IWinnerController
    {
        public string? GetWinnerOfTheRound(Round round);
        public Player? GetWinnerOfTheMatch(Match match);
        public Player GetTossResult(List<Player> players);
    }
}
