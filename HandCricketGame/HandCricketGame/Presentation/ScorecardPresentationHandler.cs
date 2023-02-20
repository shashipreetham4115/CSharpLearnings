using HandCricketGame.Controller.Contract;
using HandCricketGame.Model;
using HandCricketGame.Presentation.Contract;

namespace HandCricketGame.Presentation
{
    public class ScorecardPresentationHandler : IPresentationHandler
    {
        protected IRecentGameChooser RecentGameChooser;
        protected IDisplay DisplayGame;

        public ScorecardPresentationHandler(IRecentGameChooser recentGameChooser, IDisplay displayGame) 
        {
            RecentGameChooser = recentGameChooser;
            DisplayGame = displayGame;
        }

        public void Handle()
        {
            int sCase = 1;
            bool isMatchSelected = false;
            while (true)
            {
                switch (sCase)
                {
                    case 1:
                        isMatchSelected = RecentGameChooser.Choose();
                        if (isMatchSelected) sCase++; else sCase--;
                        break;
                    case 2:
                        DisplayGame.Display();
                        Console.WriteLine("\nPlease press Enter key to go back");
                        Console.ReadLine();
                        sCase--;
                        break;
                    default: return;
                }
            }
        }
    }
}
