namespace HandCricketGame.Model
{
    public class Player
    {
        public string Id { get; private set; }
        public string Name;

        public Player(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}