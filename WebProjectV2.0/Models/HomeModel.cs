using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;


namespace WebProjectV2._0.Models
{
    public class HomeModel
    {

        public void SignIn(String username, String password)
        {
            Console.WriteLine("postview working ");
             String connection_string = "server = 127.0.0.1; port = 3306; user = root; database = test"; //connection string used to connect to mysql database

        using var connection = new MySqlConnection(connection_string);
        //connect to the database
        if (connection.State.ToString() != "Open")
        {
          connection.Close();
            connection.Open();
        }

        Console.WriteLine(connection.State);


            using var command = connection.CreateCommand(); //create a command object
                command.CommandText = @"SELECT * FROM users WHERE email = '"+ username +"';"; //sql query goes here
            using (var reader = command.ExecuteReader())
            {
                //loop through the results or the query
                

                if(reader.Read())
                {
                 string name = String.Format("{0}", reader[0]);
                 string email = String.Format("{0}", reader[1]);

                 if((username == String.Format("{0}", reader[0]) || username == String.Format("{0}", reader[2]) )&& password == String.Format("{0}", reader[1]))
                 {
                    
                    // HttpContext.Session.SetString(SessionKeyName, name);
                     //HttpContext.Session.SetString(SessionKeyEmail, email);
                    int x = 0;
                    Int32.TryParse(String.Format("{0}", reader[3]), out x);

                    Console.WriteLine("logged in");


                }
            
                    //var name = HttpContext.Session.GetInt32(SessionKeyName);
                   // Console.WriteLine(name);
                    
                // }
                 //else
                 //{
                   // Console.WriteLine("incorrect");
                 //}
            

            }
            connection.Close();
        }



    }
}
}