using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace DBSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = "mysql60.hostland.ru";
            var database = "host1323541_itstep5";
            var port = "3306";
            var username = "host1323541_itstep";
            var pass = "269f43dc";

            var connString = "Server=" + host + ";Database=" + database + ";port=" + port + ";User Id=" + username + ";password=" + pass;
            var db = new MySqlConnection(connString);
            db.Open();

            var documents = new List<Document>();

            var history = new List<History>();
            var human = new List<Human>();
            var file = new List<File>();


            string SQL = "SELECT name, is_active FROM Human;";
            var command = new MySqlCommand { Connection = db, CommandText = SQL };
            var result = command.ExecuteReader();
            while (result.Read())
            {
                human.Add(new Human()
                {
                    Name = result.GetString("name"),
                    isActive = result.GetBoolean("is_active")
                });
            }
            result.Close();

            SQL = "SELECT Document.name, File.name, File.path FROM File, Document, Document_Files WHERE Document_Files.id_document = Document.id AND Document_Files.id_file = File.id";
            command = new MySqlCommand { Connection = db, CommandText = SQL };
            result = command.ExecuteReader();
            while (result.Read())
            {
                file.Add(new File()
                {
                    Document = result.GetString("Document"),
                    Name = result.GetString("name"),
                    Path = result.GetString("path")

                });
            }
            result.Close();

            SQL = "SELECT History.id, Document.name, History.date, History.comment FROM History, Document WHERE History.id_document = Document.id";
            command = new MySqlCommand { Connection = db, CommandText = SQL };
            result = command.ExecuteReader();
            while (result.Read())
            {
                history.Add(new History()
                {
                    id = result.GetInt32("id"),
                    Document = result.GetString("name"),
                    Date = result.GetDateTime("date"),
                    Comment = result.GetString("comment")
                });
            }
            result.Close();

            foreach (var item in file)
            {
                Console.WriteLine(item.Document + " " + item.Name + " " + item.Path);
            }

            using (var tempFile = new FileStream("human.json", FileMode.OpenOrCreate))
            {
                JsonSerializer.SerializeAsync(tempFile, human);
            }
            using (var tempFile = new FileStream("history.json", FileMode.OpenOrCreate))
            {
                JsonSerializer.SerializeAsync(tempFile, history);
            }
            using (var tempFile = new FileStream("file.json", FileMode.OpenOrCreate))
            {
                JsonSerializer.SerializeAsync(tempFile, file);
            }
        }
    }
}
