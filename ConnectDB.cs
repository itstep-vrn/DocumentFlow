using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class ConnectDB
    {
        private const string HOST = "mysql60.hostland.ru";
        private const string PORT = "3306";
        private const string DATABASE = "host1323541_itstep5";
        private const string USERNAME = "host1323541_itstep";
        private const string PASSWORD = "269f43dc";
        private const string CONNSTRING = "Server=" + HOST
            + ";Database=" + DATABASE
            + ";port=" + PORT
            + ";User Id=" + USERNAME
            + ";password=" + PASSWORD;
        private static MySqlConnection db = new MySqlConnection(CONNSTRING);
        private static MySqlCommand command = new MySqlCommand();
        public static void Open()
        {
            db.Open();
        }
        public static void Close()
        {
            db.Close();
        }
        public static void Reopen()
        {
            Close();
            Open();
        }
        public static MySqlDataReader SelectQuery(string sql)
        {
            command.Connection = db;
            command.CommandText = sql;
            var result = command.ExecuteReader();
            return result;
        }
        public static bool NoSelectQuery(string sql)
        {
            command.Connection = db;
            command.CommandText = sql;
            return command.ExecuteNonQuery() > 0;
        }
    }
}
