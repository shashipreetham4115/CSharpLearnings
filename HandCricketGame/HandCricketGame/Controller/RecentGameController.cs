using HandCricketGame.Controller.Contract;
using HandCricketGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandCricketGame.Controller
{
    public class RecentGameController : IRecentGameController
    {
        protected IDataController DataController;
        protected IResetHandler MatchHandler;
        public RecentGameController(IDataController dataController, IResetHandler matchHandler) { 
            DataController = dataController;
            MatchHandler = matchHandler;
        }

        public List<Match> GetAllMatches() 
        {
            return DataController.GetAllMatches();
        }

        public void SelectMatch(Match match) 
        {
            MatchHandler.Reset(match);
        }
    }
}
