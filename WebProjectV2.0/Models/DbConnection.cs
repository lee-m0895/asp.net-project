using Microsoft.AspNetCore.Mvc;
using MySqlConnector;


namespace WebProjectV2._0.Models;
    public class DbConnection
    {

        
        private static String connection_string = "server = 127.0.0.1; port = 3306; user = root; database = test"; //connection string used to connect to mysql database
        private MySqlConnection connection = new MySqlConnection(); //initialise instance of connection object
        
        


        //connect to the database
        public async void Connect()
        {
            connection.ConnectionString = connection_string;
            await connection.OpenAsync();
        }


        public void disconnect()
        {
            connection.Close();
        }



        //run a test sql query in order to make sure the sql database connection functions
        public string TestConnection()
        {
            string value = ""; //a empty string, this will remain null if reader dose not return a result
            using var command = connection.CreateCommand(); //create a command object
            command.CommandText = @"SELECT * FROM users WHERE name = 'lee';"; //sql query goes here

            if (connection != null)
            {
                using (var reader = command.ExecuteReader())
                {
                    //loop through the results or the query
                    while (reader.Read())
                    {
                        //format the results into a single string 
                        value = value + String.Format("{0}", reader[0]) + "  "; //first field in data
                        value = value + String.Format("{0}", reader[1]) + "  "; //second field in data
                    }
                } 
              connection.Close();                   
            }    
            return value;     
        }


        //returns the connection object so that querys can be ran from outside of the DBConnection class
        public MySqlConnection GetConnection()
        {
            return connection;
        }


        public void QueryDb(string query)
        {
            /**var result;
           using var command = connection.CreateCommand(); //create a command object
            command.CommandText = query;
            using (var reader = command.ExecuteReader())
            {
                //loop through the results or the query
                reader.Read();
                result = reader.Read();
            }
            return result;*/
        }



    }

