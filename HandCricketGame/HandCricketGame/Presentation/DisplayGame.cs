using HandCricketGame.Controller.Contract;
using HandCricketGame.Model;
using HandCricketGame.Presentation.Contract;
using HandCricketGame.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandCricketGame.Presentation
{
    public class DisplayGame : IDisplay
    {
        private IRoundHandler _RoundsHandler;
        private IDisplayWinner _DisplayWinner;

        public DisplayGame(IRoundHandler roundsHandler, IDisplayWinner displayWinner) 
        {
            _RoundsHandler= roundsHandler;
            _DisplayWinner= displayWinner;
        }

        public void Display()
        {
            _DisplayWinner.DisplayTossWinner();
            for (int i = 0; i < 3; i++) 
            {
                Console.WriteLine("------------------------------------------------------------------------------------");
                Console.WriteLine($"-------------------------------------Round-{i+1}----------------------------------------");
                Console.WriteLine("------------------------------------------------------------------------------------");
                List<Player> playerList = _RoundsHandler.GetRound(i).Players;
                for (int j = 0; j < 2; j++)
                {
                    Inning inning = _RoundsHandler.GetInning(i, j); 
                    var Gestures = _RoundsHandler.GetGestures(i, j);
                    string nonStriker = "Unknown";
                    string striker = GetPlayerName(playerList, inning.StrikerId, ref nonStriker);
                    int strikerScore = 0;
                    foreach (Delivery delivery in Gestures)
                    {
                        string status = GetGestureStatus(delivery, striker, ref strikerScore);
                        Console.WriteLine($"{striker} shows {delivery.StrikerScore} and {nonStriker} shows {delivery.BowlerScore}, {status}");
                    }
                    if(Gestures.Count() == 15)
                    {
                        Console.WriteLine($"Inning {j+1} completed by maximum(15) hand Gestures");
                    }
                }
                Console.WriteLine("------------------------------------------------------------------------------------");
                _DisplayWinner.DisplayRoundWinner(i);
            }

            _DisplayWinner.DisplayMatchWinner();
        }

        private string GetPlayerName(List<Player> playerList, string strikerId, ref string nonStriker) 
        {
            string striker = "Unknown";
            foreach (Player player in playerList) 
            {
                if(player.Id == strikerId)
                {
                    striker = player.Name;
                }
                else
                {
                    nonStriker = player.Name;
                }
            }
            return striker;
        }

        private string GetGestureStatus(Delivery delivery, string strikerName, ref int strikerScore)
        {
            string runs = (strikerScore == 1) ? "1 run" : $"{strikerScore} runs";
            if (delivery.StrikerScore == delivery.BowlerScore)
            {
                strikerScore = 0;
                return $"{strikerName} got out scoring {runs}";
            }
            else
            {
                strikerScore += delivery.StrikerScore;
                return $"{strikerName} scores {strikerScore}";
            }
        }
    }
}
