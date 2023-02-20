using HandCricketGame.Util;

namespace HandCricketGame.Model
{
    public class Inning
    {
        public string Id { get; private set; }
        public string RoundId { get; private set; }
        public string StrikerId { get; private set; }
        public List<Delivery> Deliveries { get; private set; } = new List<Delivery>(15);

        public Inning(string id, string roundId, string strikerId)
        {
            Id = id;
            RoundId = roundId;
            StrikerId = strikerId;
        }

    }
}