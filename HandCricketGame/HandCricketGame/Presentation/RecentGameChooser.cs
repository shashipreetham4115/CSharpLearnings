using HandCricketGame.Controller.Contract;
using HandCricketGame.Model;
using HandCricketGame.Presentation.Contract;
using HandCricketGame.Presentation.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandCricketGame.Presentation
{
    public class RecentGameChooser : IRecentGameChooser
    {

        protected IRecentGameController RecentGameController;
        public RecentGameChooser(IRecentGameController recentGameController) 
        {
            RecentGameController= recentGameController;
        }

        public bool Choose()
        {
            var matches = RecentGameController.GetAllMatches(); 
            DisplayDeatils(matches);
            while (matches.Count > 0)
            {
                try
                {
                    int input = InputValidator.GetInstance().GetValidInt("Please select you choice");
                    if (input == -1 || input == matches.Count+1) break;
                    var match = input switch
                    {
                        int n when (n >= 1 && n <= matches.Count) => matches[input-1] ,
                        _ => throw new InvalidDataException()
                    };
                    RecentGameController.SelectMatch(match);
                    return true;
                }
                catch
                {
                    //Console.WriteLine(e.ToString());
                    Console.WriteLine("\nPlease Enter Valid Input");
                }
            }
            return false;
        }

        private void DisplayDeatils(List<Match> matches)
        {
            if (matches.Count > 0)
            {
                Console.WriteLine($"\nPlease select a match\n");
                for (int i = 0; i < matches.Count; i++)
                {
                    var match = matches[i];
                    Console.WriteLine($"{i + 1}) {match.Date:dd MM yyyy hh:mm tt} [{match.Players[0].Name} vs {match.Players[1].Name}]");
                };
                Console.WriteLine($"{matches.Count + 1}) Back");
            }
            else
            {
                Console.WriteLine($"\nNo matches found");
            }
        }
    }
}
