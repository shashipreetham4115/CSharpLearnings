using HandCricketGame.Controller.Contract;
using HandCricketGame.Model;
using HandCricketGame.Presentation.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HandCricketGame.Presentation
{
    public class DisplayWinner : IDisplayWinner
    {
        protected IWinnerHandler WinnerHandler;
        public DisplayWinner(IWinnerHandler winnerHandler)
        {
            WinnerHandler= winnerHandler;
        }

        public void DisplayMatchWinner()
        {
            Player? player = WinnerHandler.GetWinnerOfTheMatch();
            DisplayResult(player);
        }

        public void DisplayRoundWinner(int roundNo)
        {
            Player? player = WinnerHandler.GetWinnerOfTheRound(roundNo);
            DisplayResult(player, roundNo);
        }

        public void DisplayTossWinner()
        {
            Player player = WinnerHandler.GetTossResult();
            Console.WriteLine($"\nToss won by {player.Name}");
            Console.WriteLine($"{player.Name} decides to bat first\n");
        }

        private void DisplayResult(Player? player, int roundNo = -1)
        {
            if (player == null)
            {
                Console.WriteLine("\nMatch tied\n");
            }
            else
            {
                Console.WriteLine("\n{0} won the {1}\n", player.Name, (roundNo > -1) ? $"round {roundNo + 1}" : "match");
            }
        }
    }
}
