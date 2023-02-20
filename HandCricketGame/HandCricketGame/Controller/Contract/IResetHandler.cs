using HandCricketGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandCricketGame.Controller.Contract
{
    public interface IResetHandler
    {
        public void Reset(Match match);
    }
}
