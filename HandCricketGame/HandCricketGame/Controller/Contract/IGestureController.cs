using HandCricketGame.Model;
using HandCricketGame.Util;

namespace HandCricketGame.Controller.Contract
{
    public interface IGestureController
    {
        public IEnumerable<Delivery> GetGestures(Round round, int currentRound ,int currentInning);
    }
}