using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankMachine.SqlLiteDB
{
    public static class DBContext
    {
        private const string ConnectionString = "Data Source=bank.db";
        public static void GetCards()
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM cards";
                using (var command = new SqliteCommand(selectQuery, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Card card = new Card
                        {
                            numbercard = reader.GetString(reader.GetOrdinal("numbercard")),
                            pincod = reader.GetInt32(reader.GetOrdinal("pincod")),
                            status_id = reader.GetInt32(reader.GetOrdinal("status_id")),
                            balance = reader.GetDouble(reader.GetOrdinal("balance"))
                        };

                        Data.ListCard.Add(card);
                    }
                }
                connection.Close();
            }
        }
        public static void UpdateData(Card cardget)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                string updateQuery = $"UPDATE cards SET status_id = {cardget.status_id}, balance = {cardget.balance.ToString(CultureInfo.InvariantCulture)} WHERE numbercard ={cardget.numbercard}";

                using (var command = new SQLiteCommand(updateQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        public static void GetStatus()
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM statuscard";
                using (var command = new SqliteCommand(selectQuery, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var statuscard = new Statuscard
                        {
                            id = reader.GetInt32(reader.GetOrdinal("id")),
                            statusname = reader.GetString(reader.GetOrdinal("statusname"))
                        };

                        Data.ListStatusCard.Add(statuscard);
                    }
                }
                connection.Close();
            }
        }
    }
}
