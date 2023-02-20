using HandCricketGame.Data.Contract;
using HandCricketGame.Model;
using HandCricketGame.Util;
using System.Data;
using System.Data.SQLite;
using System.Numerics;


namespace HandCricketGame.Data
{
    public class DatabaseService : IDatabaseService
    {
        private Database _database = Database.GetInstance();
        public DatabaseService()
        {
            CreateAllTablesIfNotExist();
        }

        public List<Match> GetAllMatches()
        {
/*            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();*/
            string query = "SELECT match.id as matchId, match.date, match.winnerId, match.tossWinnerId," +
                "round.id as roundId, round.winnerId," +
                "inning.id as inningId, inning.strikerId," +
                "delivery.deliveryId, delivery.strikerScore, delivery.bowlerScore" +
                " from match" +
                " join round on round.matchId = match.id" +
                " join inning on inning.roundId = round.id" +
                " join delivery on delivery.inningId = inning.id" +
                " order by delivery.id ASC;";
            _database.OpenConnection();
            var matches = GetMatchesWithPlayers(query).Result;
            _database.CloseConnection();
            /*watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");*/
            return matches;
        }

        public List<Player> GetAllPlayers()
        {
            string query = "select * from player";
            SQLiteCommand cmd = new SQLiteCommand(query, _database.Connection);
            _database.OpenConnection();
            var result = cmd.ExecuteReader();
            var players = GetAllPlayersList(result);
            _database.CloseConnection();
            return players;
        }

        public void UpdateInningScore(string inningId, int score)
        {
            string query = "update inning set score = @score where id = @inningId";
            SQLiteCommand cmd = new SQLiteCommand(query, _database.Connection);
            cmd.Parameters.AddWithValue("@inningId", inningId);
            cmd.Parameters.AddWithValue("@score", score);
            _database.OpenConnection();
            cmd.ExecuteNonQuery();
            _database.CloseConnection();
        }

        public void UpdateMatchWinnerId(string matchId, string winnerId)
        {
            string query = "update match set winnerId = @winnerId where id = @matchId";
            SQLiteCommand cmd = new SQLiteCommand(query, _database.Connection);
            cmd.Parameters.AddWithValue("@winnerId", winnerId);
            cmd.Parameters.AddWithValue("@matchId", matchId);
            _database.OpenConnection();
            cmd.ExecuteNonQuery();
            _database.CloseConnection();
        }

        public void UpdateMatchTossWinnerId(string matchId, string winnerId)
        {
            string query = "update match set tossWinnerId = @winnerId where id = @matchId";
            SQLiteCommand cmd = new SQLiteCommand(query, _database.Connection);
            cmd.Parameters.AddWithValue("@winnerId", winnerId);
            cmd.Parameters.AddWithValue("@matchId", matchId);
            _database.OpenConnection();
            cmd.ExecuteNonQuery();
            _database.CloseConnection();
        }

        public void UpdateRoundWinnerId(string roundId, string winnerId)
        {
            string query = "update round set winnerId = @winnerId where id = @roundId";
            SQLiteCommand cmd = new SQLiteCommand(query, _database.Connection);
            cmd.Parameters.AddWithValue("@winnerId", winnerId);
            cmd.Parameters.AddWithValue("@roundId", roundId);
            _database.OpenConnection();
            cmd.ExecuteNonQuery();
            _database.CloseConnection();
        }

        public void InsertMatch(Match match)
        {
            string query = "Insert into match(id, date, winnerId, tossWinnerId) Values(@id, @date, @winnerId, @tossWinnerId)";
            SQLiteCommand cmd = new SQLiteCommand(query, _database.Connection);
            cmd.Parameters.AddWithValue("@id", match.Id);
            cmd.Parameters.AddWithValue("@date", match.Date);
            cmd.Parameters.AddWithValue("@winnerId", match.WinnerId);
            cmd.Parameters.AddWithValue("@tossWinnerId", match.TossWinnerId);
            _database.OpenConnection();
            cmd.ExecuteNonQuery(); 
            _database.CloseConnection();
            InsertMatchAndPlayersRelation(match);
        }

        public void InsertMatchAndPlayersRelation(Match match)
        {
            string query = "insert into match_and_players(matchId, playerId) values(@matchId, @playerId),(@matchId1, @playerId1);";
            SQLiteCommand cmd = new SQLiteCommand(query, _database.Connection);
            cmd.Parameters.AddWithValue("@matchId", match.Id);
            cmd.Parameters.AddWithValue("@playerId", match.Players.First().Id);

            cmd.Parameters.AddWithValue("@matchId1", match.Id);
            cmd.Parameters.AddWithValue("@playerId1", match.Players.Last().Id);
            _database.OpenConnection();
            cmd.ExecuteNonQuery();
            _database.CloseConnection();
        }

        public void InsertRound(Round round)
        {
            _database.OpenConnection();
            string query = "Insert into round(id, matchId, winnerId) Values(@id, @matchId, @winnerId)";
            SQLiteCommand cmd = new SQLiteCommand(query, _database.Connection);
            cmd.Parameters.AddWithValue("@id", round.Id);
            cmd.Parameters.AddWithValue("@winnerId", round.WinnerId);
            cmd.Parameters.AddWithValue("@matchId", round.MatchId);
            cmd.ExecuteNonQuery();
            _database.CloseConnection();
        }

        public void InsertInning(Inning inning)
        {
            _database.OpenConnection();
            string query = "Insert into inning(id, roundId, strikerId) Values(@id, @roundId, @strikerId)";
            SQLiteCommand cmd = new SQLiteCommand(query, _database.Connection);
            cmd.Parameters.AddWithValue("@id", inning.Id);
            cmd.Parameters.AddWithValue("@roundId", inning.RoundId);
            cmd.Parameters.AddWithValue("@strikerId", inning.StrikerId);
            cmd.ExecuteNonQuery();
            _database.CloseConnection();
        }

        public void InsertDelivery(Delivery delivery)
        {
            _database.OpenConnection();
            string query = "Insert into delivery(deliveryId, inningId, strikerScore, bowlerScore) " +
                "Values(@deliveryId, @inningId, @strikerScore, @bowlerScore)";
            SQLiteCommand cmd = new SQLiteCommand(query, _database.Connection);
            cmd.Parameters.AddWithValue("@deliveryId", delivery.Id);
            cmd.Parameters.AddWithValue("@inningId", delivery.InningId);
            cmd.Parameters.AddWithValue("@strikerScore", delivery.StrikerScore);
            cmd.Parameters.AddWithValue("@bowlerScore", delivery.BowlerScore);
            cmd.ExecuteNonQuery();
            _database.CloseConnection();
        }

        public void InsertPlayer(Player player)
        {
            string query = "Insert into player(id, name) Values(@id, @name);";
            SQLiteCommand cmd = new SQLiteCommand(query, _database.Connection);
            cmd.Parameters.AddWithValue("@id", player.Id);
            cmd.Parameters.AddWithValue("@name", player.Name);
            _database.OpenConnection();
            cmd.ExecuteNonQuery();
            _database.CloseConnection();
        }


        private void CreateAllTablesIfNotExist()
        {
            _database.OpenConnection();
            TurnONForeignKeyOnDb();
            CreateMatchTableIfNotExist();
            CreateRoundTableIfNotExist();
            CreateInningsTableIfNotExist();
            CreateDeliveryTableIfNotExists();
            CreatePlayerTableIfNotExists();
            CreateMatchAndPlayerRelationTableIfNotExist();
            CreateIndexesIfNotExists();
            _database.CloseConnection();
        }

        private void TurnONForeignKeyOnDb()
        {
            string query = "PRAGMA foreign_keys = ON;";
            SQLiteCommand cmd = new SQLiteCommand(query, _database.Connection);
            cmd.ExecuteNonQuery();
        }

        private void CreateIndexesIfNotExists()
        {
            string query = "create index if not exists idx_round_matchId on round(matchId);" +
                "create index if not exists idx_inning_strikerId_and_roundId on inning(roundId, strikerId);" +
                "create index if not exists idx_delivery_inningId on delivery(inningId);";

            SQLiteCommand cmd = new SQLiteCommand(query, _database.Connection);
            cmd.ExecuteNonQuery();
        }

        private void CreateMatchTableIfNotExist()
        {
            string query = "CREATE TABLE IF NOT EXISTS match(" +
                "id TEXT NOT NULL PRIMARY KEY," +
                "date DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP," +
                "winnerId TEXT," +
                "tossWinnerId TEXT," +
                "FOREIGN KEY (winnerId) REFERENCES player(id)," +
                "FOREIGN KEY (tossWinnerId) REFERENCES player(id));";
            SQLiteCommand cmd = new SQLiteCommand(query, _database.Connection);
            cmd.ExecuteNonQuery();
        }

        private void CreateRoundTableIfNotExist()
        {
            string query = "CREATE TABLE IF NOT EXISTS round(" +
                "id TEXT NOT NULL PRIMARY KEY," +
                "matchId TEXT NOT NULL," +
                "winnerId INTEGER," +
                "FOREIGN KEY (matchId) REFERENCES match(id)," +
                "FOREIGN KEY (winnerId) REFERENCES player(id));";
            SQLiteCommand cmd = new SQLiteCommand(query, _database.Connection);
            cmd.ExecuteNonQuery();
        }

        private void CreateInningsTableIfNotExist()
        {
            string query = "CREATE TABLE IF NOT EXISTS inning(" +
                "id TEXT NOT NULL PRIMARY KEY," +
                "roundId TEXT NOT NULL," +
                "strikerId INTEGER NOT NULL," +
                "FOREIGN KEY (roundId) REFERENCES round(id)," +
                "FOREIGN KEY (strikerId) REFERENCES player(id));";
            SQLiteCommand cmd = new SQLiteCommand(query, _database.Connection);
            cmd.ExecuteNonQuery();
        }

        private void CreateDeliveryTableIfNotExists()
        {
            string query = "CREATE TABLE IF NOT EXISTS delivery(" +
                "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                "deliveryId INTEGER NOT NULL," +
                "inningId TEXT NOT NULL," +
                "strikerScore INTEGER NOT NULL," +
                "bowlerScore INTEGER NOT NULL," +
                "FOREIGN KEY (inningId) REFERENCES inning(id));";
            SQLiteCommand cmd = new SQLiteCommand(query, _database.Connection);
            cmd.ExecuteNonQuery();
        }

        private void CreatePlayerTableIfNotExists()
        {
            string query = "CREATE TABLE IF NOT EXISTS player(" +
               "id TEXT NOT NULL PRIMARY KEY," +
               "name TEXT NOT NULL);";
            SQLiteCommand cmd = new SQLiteCommand(query, _database.Connection);
            cmd.ExecuteNonQuery();
        }

        private void CreateMatchAndPlayerRelationTableIfNotExist()
        {
            string query = "CREATE TABLE IF NOT EXISTS match_and_players(" +
               "matchId TEXT NOT NULL," +
               "playerId TEXT NOT NULL);";
            SQLiteCommand cmd = new SQLiteCommand(query, _database.Connection);
            cmd.ExecuteNonQuery();
        }


        private Dictionary<string,List<Player>> GetMatchPlayers()
        {
            string query = "select match_and_players.matchId, player.id, player.name from match_and_players " +
                "join player where player.id = match_and_players.playerId";
            SQLiteCommand cmd = new SQLiteCommand(query, _database.Connection);
            _database.OpenConnection();
            var result = cmd.ExecuteReader();
            var players = GetAllPlayersWithMatchId(result);
            _database.CloseConnection();
            return players;
        }

        private Dictionary<string, List<Player>> GetAllPlayersWithMatchId(SQLiteDataReader result)
        {
            var players = new Dictionary<string, List<Player>>();
            while (result.Read())
            {
                string matchId = result.GetString(0);
                if (!players.ContainsKey(matchId))
                {
                    players[matchId] = new List<Player>();
                }
                var player = new Player(result.GetString(1), result.GetString(2));
                players[matchId].Add(player);
            }
            return players;
        }

        private List<Player> GetAllPlayersList(SQLiteDataReader result)
        {
            var players = new List<Player>();
            while (result.Read())
            {
                players.Add(new Player(result.GetString(0), result.GetString(1)));
            }
            return players;
        }

        private async Task<List<Match>> GetMatchesWithPlayers(string query)
        {
            SQLiteCommand cmd = new SQLiteCommand(query, _database.Connection);
            var matchesTask = Task.Run(() => {
                var result = cmd.ExecuteReader();
                return GetMatchList(result);
            });
            var playersTask = Task.Run(() => { return GetMatchPlayers(); });
            await Task.WhenAll(matchesTask, playersTask);
            var matches = await matchesTask;
            var players = await playersTask;
            matches.ForEach(match => {
                match.Players.AddRange(players[match.Id]);
            });
            return matches;
        }

        private List<Match> GetMatchList(SQLiteDataReader result)
        {
            List<Match> matches = new List<Match>();
            string lastMatchId = "", lastInningId = "", lastRoundId = "";
            while (result.Read())
            {
                // Ids
                var currentMatchId = result.GetString(0);
                var currentRoundId = result.GetString(4);
                var currentInningId = result.GetString(6);

                if (lastMatchId != currentMatchId)
                {
                    var match = new Match(currentMatchId, result.GetDateTime(1), result.GetString(2), result.GetString(3));
                    matches.Add(match);
                    lastMatchId = currentMatchId;
                }
                if (lastRoundId != currentRoundId)
                {
                    var round = new Round(currentRoundId, currentMatchId, result.GetString(5));
                    round.Players = matches.Last().Players;
                    matches.Last().Rounds.Add(round);
                    lastRoundId = currentRoundId;
                }
                if (lastInningId != currentInningId)
                {
                    var inning = new Inning(currentInningId, currentRoundId, result.GetString(7));
                    matches.Last().Rounds.Last().Innings.Add(inning);
                    lastInningId = currentInningId;
                }
                var delivery = new Delivery(result.GetInt32(8), currentInningId, result.GetInt32(9), result.GetInt32(10));
                matches.Last().Rounds.Last().Innings.Last().Deliveries.Add(delivery);
            }
            return matches;
        }
    }

}
