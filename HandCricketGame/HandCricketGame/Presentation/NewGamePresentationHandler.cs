using HandCricketGame.Controller.Contract;
using HandCricketGame.Presentation.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandCricketGame.Presentation
{
    public class NewGamePresentationHandler : IPresentationHandler
    {
        protected INewGameController NewGameController;
        protected IDisplay DisplayGame;
        public NewGamePresentationHandler(INewGameController newGameController, IDisplay displayGame) 
        {
            NewGameController = newGameController;
            DisplayGame = displayGame;
        }

        public void Handle()
        {
            NewGameController.StartMatch();
            DisplayGame.Display();
        }
    }
}
