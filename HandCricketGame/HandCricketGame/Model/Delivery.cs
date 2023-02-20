using HandCricketGame.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandCricketGame.Model
{
    public class Delivery
    {
        public int Id { get; private set; }
        public string InningId { get; private set; }
        public int StrikerScore;
        public int BowlerScore;

        public Delivery(int id, string inningId, int stikerScore, int bowlerScore) 
        {
            Id = id;
            InningId = inningId;
            StrikerScore = stikerScore;
            BowlerScore = bowlerScore;
        }
    }
}
