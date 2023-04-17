using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Xml.XPath;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TCPServer
{
    class Database
    {
        public void main()
        {
            // Set the name and path of the new database file
            string databaseFile = "mydatabase.db";
            // Create a new SQLite database file
            SQLiteConnection.CreateFile(databaseFile);

            string connectionString = "Data Source=" + databaseFile + ";Version=3;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            //openDatabase();

            createTable();

            connection.Close();
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
                "status TEXT)";
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
                Console.WriteLine("User logged in successfully.");
                result = 1;
            }
            else
            {
                // User does not exist or password is incorrect
                Console.WriteLine("Invalid username or password.");
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
            string sql = "INSERT INTO playerData (name, password, currentIP) VALUES (@name, @password, @currentIP)";
            SQLiteCommand command = new SQLiteCommand(sql, connection);

            // Set the parameter values for the SQL command
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@currentIP", ip);

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

        public void setElo()
        {

        }
        public void leaderBoard()
        {

        }
    }
}
