using HandCricketGame.Data.Contract;
using HandCricketGame.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandCricketGame.Test
{
    public class DatabaseService
    {
        private Database _database = Database.GetInstance();
        public DatabaseService()
        {
            CreateAllTablesIfNotExist();
        }


        public void GetPlayers()
        {
            string query = "select * from player";
            var result = ReadData(query);
            while(result.Read())
            {
                Console.WriteLine($"{result.GetInt32(0), -3} {result.GetString(1)}");
            }
            if(result == null)
            {
                Console.WriteLine("No Records Found\n");
            }
            _database.CloseConnection();
        }

        private SQLiteDataReader ReadData(string query)
        {
            _database.OpenConnection();
            SQLiteCommand cmd = new SQLiteCommand(query, _database.Connection);
            var result = cmd.ExecuteReader();
            return result;
        }

        public void InsertData()
        {
            _database.OpenConnection();
            string querry = "insert into player(name) values('Shashi');";
            SQLiteCommand cmd = new SQLiteCommand(querry, _database.Connection);
            cmd.ExecuteNonQuery();
            _database.CloseConnection();   
        }

        private void CreateAllTablesIfNotExist()
        {
            _database.OpenConnection();
            CreatePlayerTableIfNotExists();
            _database.CloseConnection();
        }

        private void CreatePlayerTableIfNotExists()
        {
            string query = "CREATE TABLE IF NOT EXISTS player(" +
               "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
               "name TEXT NOT NULL);";
            SQLiteCommand cmd = new SQLiteCommand(query, _database.Connection);
            cmd.ExecuteNonQuery();
        }
    }
}
