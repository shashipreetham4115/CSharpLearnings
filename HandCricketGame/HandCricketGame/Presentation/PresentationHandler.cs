using HandCricketGame.Presentation.Contract;

namespace HandCricketGame.Presentation
{
    internal class PresentationHandler : IPresentationHandler
    {
        private IMainMenuChooser MainMenuChooser;
        private IPresentationHandler NewGamePresentationHandler;
        private IPresentationHandler ScorecardPresentationHandler;
        public PresentationHandler(IMainMenuChooser mainMenuChooser, IPresentationHandler newGamePresentationHandler, IPresentationHandler scorecardPresenterHandler) 
        { 
            MainMenuChooser= mainMenuChooser;
            NewGamePresentationHandler = newGamePresentationHandler;
            ScorecardPresentationHandler= scorecardPresenterHandler;
        }

        public void Handle()
        {
            while (true)
            {
                switch (MainMenuChooser.Choose())
                {
                    case 1:
                        
                            NewGamePresentationHandler.Handle();
                        
                        break;

                    case 2:
                        ScorecardPresentationHandler.Handle();
                        break;

                    default:
                        Console.WriteLine("Thank you, visit again");
                        return;
                }
            }
        }
    }
}
