using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HandCricketGame.Data
{
    public class Database
    {

        private static Database? Instance = null;
        public SQLiteConnection Connection { get; private set; }
        private int ongoingTasksCount = 0;

        private Database()
        {
            Connection = new SQLiteConnection("Data Source=hand_cricket.sqlite3");
            if (!File.Exists("./hand_cricket.sqlite3"))
            {
                SQLiteConnection.CreateFile("hand_cricket.sqlite3");
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
            ongoingTasksCount++;
            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }
        }

        public void CloseConnection()
        {
            ongoingTasksCount--;
            if (Connection.State != ConnectionState.Closed && ongoingTasksCount == 0)
            {
                Connection.Close();
            }
        }
    }
}
