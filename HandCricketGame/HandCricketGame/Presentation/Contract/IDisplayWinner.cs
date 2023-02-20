using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandCricketGame.Presentation.Contract
{
    public interface IDisplayWinner
    {
        public void DisplayMatchWinner();
        public void DisplayRoundWinner(int roundNo);

        public void DisplayTossWinner();
    }
}
