using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketBookingSystem.Data
{
    internal class Database
    {
        private static Database? Instance = null;
        public SQLiteConnection Connection { get; private set; }

        private Database() 
        {
            Connection = new SQLiteConnection("Data Source=movie_ticket_booking_system.sqlite3");
            if (!File.Exists("./movie_ticket_booking_system.sqlite3"))
            {
                SQLiteConnection.CreateFile("movie_ticket_booking_system.sqlite3");
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
