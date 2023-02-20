using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandCricketGame.Test
{
    public class Database
    {

        private static Database? Instance = null;
        public SQLiteConnection Connection { get; private set; }

        private Database()
        {
            Connection = new SQLiteConnection("Data Source=practice_1.sqlite3");
            if (!File.Exists("./practice_1.sqlite3"))
            {
                SQLiteConnection.CreateFile("practice_1.sqlite3");
                Console.WriteLine("Database created successfully");
            }
        }

        public static Database GetInstance()
        {
            if (Instance == null)
            {
                Instance = new Database();
            }
            return Instance;
        }


        public void OpenConnection()
        {
            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();

            }
        }

        public void CloseConnection()
        {
            if (Connection.State != ConnectionState.Closed)
            {
                Connection.Close();
            }
        }
    }
}
