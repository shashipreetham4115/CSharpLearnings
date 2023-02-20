using HandCricketGame.Presentation.Contract;
using HandCricketGame.Presentation.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandCricketGame.Presentation
{
    public class MainMenuChooser : IMainMenuChooser
    {
        private int OptionCount = 0;
        public int Choose()
        {
            DisplayDeatils();
            while (true)
            {
                try
                {
                    int input = InputValidator.GetInstance().GetValidInt("Please select you choice");
                    if (input == -1 || input == OptionCount) break;
                    return input switch
                    {
                        int n when (n >= 1 && n <= OptionCount) => n,
                        _ => throw new InvalidDataException()
                    };
                }
                catch
                {
                    //Console.WriteLine(e.ToString());
                    Console.WriteLine("\nPlease Enter Valid Input");
                }
            }
            return -1;
        }

        private void DisplayDeatils()
        {
            OptionCount = 0;
            Console.WriteLine($"\n{++OptionCount}) Start New Game");
            Console.WriteLine($"{++OptionCount}) Recent Matches Scorecard");
            Console.WriteLine($"{++OptionCount}) Exit\n");
        }
    }
}
