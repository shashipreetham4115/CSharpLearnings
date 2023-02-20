using HandCricketGame.Controller.Contract;
using HandCricketGame.Model;
using HandCricketGame.Util;

namespace HandCricketGame.Controller
{
    public class GestureRoundController : IGestureController
    {
        protected IDataController DataController;
        protected UniqueIdGenerator UniqueIdGenerator = UniqueIdGenerator.GetInstance();
        public GestureRoundController(IDataController dataController) 
        {
            DataController = dataController;
        }

        public IEnumerable<Delivery> GetGestures(Round round,int currentRound, int currentInning)
        {
            var inning = round.Innings[currentInning];
            var maxIterations = (inning.Deliveries.Count() > 0) ? inning.Deliveries.Count() : 15;
            int inning1Score = (currentInning == 1) ? GetInningScore(round.Innings[0]) : -1;
            int score = 0;
            for (int i = 0; i < maxIterations; i++)
            {
                Delivery delivery;
                if (inning.Deliveries.Count <= i)
                {
                    /*Thread.Sleep(300);*/
                    var id = int.Parse($"{currentRound+1}{currentInning+1}{i+1}");
                    delivery = new Delivery(id, inning.Id, new Random().Next(6), new Random().Next(6));
                    DataController.AddDelivery(delivery);
                    if (delivery.StrikerScore != delivery.BowlerScore) score += delivery.StrikerScore;
                    if (inning1Score > -1 && score > inning1Score)
                    {
                        yield return delivery;
                        break;
                    }
                }
                else
                {
                    delivery = inning.Deliveries[i];
                }
                yield return delivery;
                if (delivery.StrikerScore == delivery.BowlerScore)
                {
                    break;
                }
            }
        }

        private int GetInningScore(Inning inning)
        {
            return inning.Deliveries.Sum(delivery => delivery.StrikerScore);
        }
    }
}
