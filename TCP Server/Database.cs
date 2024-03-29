﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Xml.XPath;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using System.Security.Cryptography;

namespace TCPServer
{
    class Database
    {
        public void main()
        {
            // Set the name and path of the new database file
            string databaseFile = "mydatabase.db";

            // Check if the database file exisits
            // If it does NOT create the database file
            if (!File.Exists(databaseFile)) 
            {
                // Create a new SQLite database file
                SQLiteConnection.CreateFile(databaseFile);
            }
            
            string connectionString = "Data Source=" + databaseFile + ";Version=3;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            //openDatabase();

            createTable();

            connection.Close();
        }

        public bool checkDB()
        {
            // Open the connection
            string databaseFile = "mydatabase.db";
            string connectionString = "Data Source=" + databaseFile + ";Version=3;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();

            // Define the SQL command to count the number of rows in the table
            string sql = "SELECT COUNT(*) FROM playerData";
            SQLiteCommand command = new SQLiteCommand(sql, connection);

            // Execute the SQL command and retrieve the count
            int rowCount = Convert.ToInt32(command.ExecuteScalar());

            // Check if there are any entries in the table
            bool hasEntries = rowCount > 0;

            // Close the connection
            connection.Close();

            return hasEntries;
        }

        void openDatabase()
        {
            string databaseFile = "mydatabase.db";
            string connectionString = "Data Source=" + databaseFile + ";Version=3;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
        }

        public void createTable()
        {
            // Open the connection
            string databaseFile = "mydatabase.db";
            string connectionString = "Data Source=" + databaseFile + ";Version=3;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();

            string sql = "CREATE TABLE IF NOT EXISTS playerData (" +
                "id INTEGER PRIMARY KEY, " +
                "name TEXT, " +
                "password TEXT, " +
                "currentIP TEXT," +
                "status TEXT," +
                "elo TEXT)";
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();

            connection.Close(); 
        }

        public int checkUserName(string name, string password, string ip)
        {
            int result = 0;

            // Open the connection
            string databaseFile = "mydatabase.db";
            string connectionString = "Data Source=" + databaseFile + ";Version=3;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();

            // Define the SQL command with parameters for the data to be selected
            string sql = "SELECT COUNT(*) FROM playerData WHERE name = @name";
            SQLiteCommand command = new SQLiteCommand(sql, connection);

            // Set the parameter values for the SQL command
            command.Parameters.AddWithValue("@name", name);

            // Execute the SQL command and get the count of matching rows
            int count = Convert.ToInt32(command.ExecuteScalar());

            connection.Close();

            if (getOnlineStatus(name))
            {
                result = 4;
            }
            else
            {
                // Check if the name already exists
                if (count > 0)
                {
                    // Name already exists
                    result = checkPlayerDetails(name, password, ip);
                }
                else
                {
                    // Name does not exist
                    // Insert the new user into the playerData table
                    result = addPlayer(name, password, ip);
                }
            }
            return result;
        }

        public int checkPlayerDetails(string name, string password, string ip)
        {
            int result = 0;

            // Open the connection
            string databaseFile = "mydatabase.db";
            string connectionString = "Data Source=" + databaseFile + ";Version=3;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();

            // Define the SQL command with parameters for the data to be selected
            string sql = "SELECT COUNT(*) FROM playerData WHERE name = @name AND password = @password";
            SQLiteCommand command = new SQLiteCommand(sql, connection);

            // Set the parameter values for the SQL command
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@password", password);

            // Execute the SQL command and get the count of matching rows
            int count = Convert.ToInt32(command.ExecuteScalar());

            connection.Close();

            // Check if the user exists and the password is correct
            if (count > 0)
            {
                // User exists and password is correct
                //Console.WriteLine("User logged in successfully.");
                result = 1;
            }
            else
            {
                // User does not exist or password is incorrect
                //Console.WriteLine("Invalid username or password.");
                result = 2;
            }

            return result;
        }

        public int addPlayer(string name, string password, string ip)
        {
            int result = 0;

            // Open the connection
            string databaseFile = "mydatabase.db";
            string connectionString = "Data Source=" + databaseFile + ";Version=3;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();

            // Define the SQL command with parameters for the data to be inserted
            string sql = "INSERT INTO playerData (name, password, currentIP, elo, status) VALUES (@name, @password, @currentIP, @elo, @status)";
            SQLiteCommand command = new SQLiteCommand(sql, connection);

            // Set the parameter values for the SQL command
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@currentIP", ip);
            command.Parameters.AddWithValue("@elo", 500);
            command.Parameters.AddWithValue("@status", "online");

            // Execute the SQL command
            command.ExecuteNonQuery();

            connection.Close();

            result = 3;

            return result;
        }

        public bool getOnlineStatus(string name)
        {
            bool result = false;

            // Open the connection
            string databaseFile = "mydatabase.db";
            string connectionString = "Data Source=" + databaseFile + ";Version=3;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();

            // Define the SQL command with parameters for the data to be selected
            string sql = "SELECT status FROM playerData WHERE name = @name";
            SQLiteCommand command = new SQLiteCommand(sql, connection);

            // Set the parameter values for the SQL command
            command.Parameters.AddWithValue("@name", name);

            // Execute the SQL command and get the matching row
            SQLiteDataReader reader = command.ExecuteReader();

            // Check if a matching row was found
            if (reader.Read())
            {
                string status = reader.GetString(0);
                if (status == "online")
                {
                    result = true;
                }
                else
                {
                    result = false; 
                }
            }

            // Close the reader and the connection
            reader.Close();
            connection.Close();

            return result;
        }

        public void setOnlineStatus(string currentIP, string status)
        {
            // Open the connection
            string databaseFile = "mydatabase.db";
            string connectionString = "Data Source=" + databaseFile + ";Version=3;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();

            // Define the SQL command with parameters for the data to be updated
            string sql = "UPDATE playerData SET status = @status WHERE currentIP = @currentIP";
            SQLiteCommand command = new SQLiteCommand(sql, connection);

            // Set the parameter values for the SQL command
            command.Parameters.AddWithValue("@status", status);
            command.Parameters.AddWithValue("@currentIP", currentIP);

            // Execute the SQL command to update the "status" column for the user
            command.ExecuteNonQuery();

            connection.Close();
        }

        public List<string> getAllOnline()
        {
            // Open the connection
            string databaseFile = "mydatabase.db";
            string connectionString = "Data Source=" + databaseFile + ";Version=3;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();

            // Define the SQL command with parameters for the data to be selected
            string sql = "SELECT name FROM playerData WHERE status = 'online'";
            SQLiteCommand command = new SQLiteCommand(sql, connection);

            // Execute the SQL command and get the matching row
            SQLiteDataReader reader = command.ExecuteReader();

            List<string> userNames = new List<string>();
            while (reader.Read()) 
            {
                string userName = reader.GetString(0);
                userNames.Add(userName);
            }

            reader.Close();
            connection.Close();

            return userNames;
        }

        public void setAllOffline()
        {
            // Open the connection
            string databaseFile = "mydatabase.db";
            string connectionString = "Data Source=" + databaseFile + ";Version=3;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();

            // Define the SQL command with parameters for the data to be updated
            string sql = "UPDATE playerData SET status = 'offline'";
            SQLiteCommand command = new SQLiteCommand(sql, connection);

            // Execute the SQL command to update the "status" column for the user
            command.ExecuteNonQuery();

            connection.Close();
        }

        public void setIp(string name, string currentIP)
        {
            // Open the connection
            string databaseFile = "mydatabase.db";
            string connectionString = "Data Source=" + databaseFile + ";Version=3;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();

            // Define the SQL command with parameters for the data to be updated
            string sql = "UPDATE playerData SET currentIP = @currentIP WHERE name = @name";
            SQLiteCommand command = new SQLiteCommand(sql, connection);

            // Set the parameter values for the SQL command
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@currentIP", currentIP);

            // Execute the SQL command to update the "status" column for the user
            command.ExecuteNonQuery();

            connection.Close();
        }

        public string getIp(string name)
        {
            // Open the connection
            string databaseFile = "mydatabase.db";
            string connectionString = "Data Source=" + databaseFile + ";Version=3;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();

            // Define the SQL command with parameters for the data to be selected
            string sql = "SELECT currentIP FROM playerData WHERE name = @name";
            SQLiteCommand command = new SQLiteCommand(sql, connection);

            // Set the parameter values for the SQL command
            command.Parameters.AddWithValue("@name", name);

            // Execute the SQL command and get the matching row
            object result = command.ExecuteScalar();

            // Close the connection
            connection.Close();

            string ip = (string)result;

            return ip;
        }

        public int getElo(string name)
        {
            // Open the connection
            string databaseFile = "mydatabase.db";
            string connectionString = "Data Source=" + databaseFile + ";Version=3;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();

            // Define the SQL command with parameters for the data to be selected
            string sql = "SELECT elo FROM playerData WHERE name = @name";
            SQLiteCommand command = new SQLiteCommand(sql, connection);

            // Set the parameter values for the SQL command
            command.Parameters.AddWithValue("@name", name);

            // Execute the SQL command and get the matching row
            object result = command.ExecuteScalar();

            // Close the connection
            connection.Close();

            int elo = int.Parse((string)result);

            return elo;
        }

        public void setElo(string name, bool result)
        {
            int currentElo = getElo(name);
            int newElo;

            // Open the connection
            string databaseFile = "mydatabase.db";
            string connectionString = "Data Source=" + databaseFile + ";Version=3;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();

            // Define the SQL command with parameters for the data to be selected
            string sql = "UPDATE playerData SET elo = @elo WHERE name = @name";
            SQLiteCommand command = new SQLiteCommand(sql, connection);

            // True means a win
            if (result == true)
            {
                newElo = currentElo + 50;
            }
            else
            {
                if (currentElo == 0)
                {
                    newElo = currentElo;
                }
                else
                {
                    newElo = currentElo - 50;
                }
            }

            // Set the parameter values for the SQL command
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@elo", newElo.ToString());
            

            // Execute the SQL command
            command.ExecuteNonQuery();

            // Close the connection
            connection.Close();

        }

        public string getName(string ip)
        {
            // Open the connection
            string databaseFile = "mydatabase.db";
            string connectionString = "Data Source=" + databaseFile + ";Version=3;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();

            // Define the SQL command with parameters for the data to be selected
            string sql = "SELECT name FROM playerData WHERE currentIP = @ip";
            SQLiteCommand command = new SQLiteCommand(sql, connection);

            // Set the parameter values for the SQL command
            command.Parameters.AddWithValue("@ip", ip);

            // Execute the SQL command and get the result
            string name = (string)command.ExecuteScalar();

            // Close the connection
            connection.Close();

            return name;
        }

        public DataTable getLeaderBoard()
        {
            // Open the connection
            string databaseFile = "mydatabase.db";
            string connectionString = "Data Source=" + databaseFile + ";Version=3;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();

            // Define the SQL command with parameters for the data to be selected
            string sql = "SELECT name, elo FROM playerData";
            SQLiteCommand command = new SQLiteCommand(sql, connection);

            // Create the datatable to store the result
            DataTable dt = new DataTable();

            // Execute the SQL command and get the result
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
            dataAdapter.Fill(dt);

            // Close the connection
            connection.Close();

            return dt;
        }
    }
}
