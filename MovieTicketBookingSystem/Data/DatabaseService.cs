using MovieTicketBookingSystem.Data.Contract;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketBookingSystem.Data
{
    public class DatabaseService : IDatabaseService
    {
        private Database _database = Database.GetInstance();
        public DatabaseService() 
        {
            CreateTables();
        }

        public void CreateTables()
        {
            _database.OpenConnection();
            CreateTheatresTableIfNotCreated();
            CreateMoviesTableIfNotCreated();
            CreateShowsTableIfNotCreated();
            CreateSeatTableIfNotCreated();
            CreateTicketsTableIfNotCreated();
            CreateMoviesInTheatresTableIfNotCreated();
            CreateShowsInMoviesTableIfNotCreated();
            _database.CloseConnection();
        }

        private void CreateTheatresTableIfNotCreated()
        {
            string query = "CREATE TABLE IF NOT EXISTS theatre(" +
                "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                "name TEXT NOT NULL," +
                "location TEXT NOT NULL," +
                "isopen INTEGER(1) DEFAULT 1 NOT NULL);";
            SQLiteCommand cmd = new SQLiteCommand(query,_database.Connection);
            cmd.ExecuteNonQuery();
        }

        private void CreateMoviesTableIfNotCreated()
        {
            string query = "CREATE TABLE IF NOT EXISTS movie(" +
                "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                "name TEXT NOT NULL);";
            SQLiteCommand cmd = new SQLiteCommand(query, _database.Connection);
            cmd.ExecuteNonQuery();
        }

        private void CreateShowsTableIfNotCreated()
        {
            string query = "CREATE TABLE IF NOT EXISTS show(" +
                "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                "screen INTEGER," +
                "date DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP," +
                "total_tickets INTEGER NOT NULL," +
                "available_tickets INTEGER NOT NULL," +
                "status INTEGER NOT NULL DEFAULT 0" +
                ");";
            SQLiteCommand cmd = new SQLiteCommand(query, _database.Connection);
            cmd.ExecuteNonQuery();
        }

        private void CreateSeatTableIfNotCreated()
        {
            string query = "CREATE TABLE IF NOT EXISTS seat(" +
                "show_id INTEGER NOT NULL," +
                "sno INTEGER NOT NULL," +
                "row INTEGER(2) NOT NULL," +
                "status INTEGER NOT NULL DEFAULT 0," +
                "FOREIGN KEY (show_id) REFERENCES show(id)" +
                ");";
            SQLiteCommand cmd = new SQLiteCommand(query, _database.Connection);
            cmd.ExecuteNonQuery();
        }

        private void CreateTicketsTableIfNotCreated()
        {
            string query = "CREATE TABLE IF NOT EXISTS ticket(" +
                "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                "show_id INTEGER NOT NULL," +
                "movie_id INTEGER NOT NULL," +
                "theatre_id INTEGER NOT NULL," +
                "date DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP," +
                "seats TEXT NOT NULL," +
                "FOREIGN KEY (show_id) REFERENCES show(id)," +
                "FOREIGN KEY (movie_id) REFERENCES movie(id)," +
                "FOREIGN KEY (theatre_id) REFERENCES theatre(id)" +
                ");";
            SQLiteCommand cmd = new SQLiteCommand(query, _database.Connection);
            cmd.ExecuteNonQuery();
        }

        private void CreateMoviesInTheatresTableIfNotCreated()
        {
            string query = "CREATE TABLE IF NOT EXISTS movie_and_theatre(" +
                "movie_id INTEGER NOT NULL," +
                "theatre_id INTEGER NOT NULL," +
                "date DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP," +
                "FOREIGN KEY (movie_id) REFERENCES movie(id)," +
                "FOREIGN KEY (theatre_id) REFERENCES theatre(id)" +
                ");";
            SQLiteCommand cmd = new SQLiteCommand(query, _database.Connection);
            cmd.ExecuteNonQuery();
        }

        private void CreateShowsInMoviesTableIfNotCreated()
        {
            string query = "CREATE TABLE IF NOT EXISTS show_and_movie(" +
                "movie_id INTEGER NOT NULL," +
                "show_id INTEGER NOT NULL," +
                "FOREIGN KEY (show_id) REFERENCES show(id)," +
                "FOREIGN KEY (movie_id) REFERENCES movie(id)" +
                ");";
            SQLiteCommand cmd = new SQLiteCommand(query, _database.Connection);
            cmd.ExecuteNonQuery();
        }
    }
}
