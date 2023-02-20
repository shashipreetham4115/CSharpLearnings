namespace HandCricketGame.Model
{
    public class Round
    {
        public string Id { get; private set; }
        public string MatchId { get; private set; }
        public string WinnerId;
        public List<Inning> Innings = new List<Inning>(2);
        public List<Player> Players = new List<Player>(2);

        public Round(string id, string matchId, string winnerId = "")
        {
            Id = id;
            MatchId = matchId;
            WinnerId = winnerId;
        }
    }
}