using HandCricketGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandCricketGame.Presentation.Contract
{
    public interface IRecentGameChooser
    {
        public bool Choose();
    }
}
