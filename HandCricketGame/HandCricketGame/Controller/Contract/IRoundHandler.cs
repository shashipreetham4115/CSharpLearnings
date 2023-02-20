using HandCricketGame.Model;
using HandCricketGame.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandCricketGame.Controller.Contract
{
    public interface IRoundHandler
    {
        public Round GetRound(int currentRound);

        public Inning GetInning(int currentRound, int currentInning);

        public IEnumerable<Delivery> GetGestures(int currentRound, int currentInning);
    }
}
