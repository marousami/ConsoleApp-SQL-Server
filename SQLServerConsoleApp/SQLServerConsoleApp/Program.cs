using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharpSqlServer
{
    class Program
    {
        static void Main(string[] args)
        {

            using (SqlConnection conn = new SqlConnection())
            {

                /* This code is used to explain how to connect SQL Database to C# console application 
                 * and How to display the data from the Database table

                // Create the connectionString
                                      /*"Server=[server_name];Database=[database_name];Trusted_Connection=true";*/
                conn.ConnectionString = "Server=DEVICE\\SQLEXPRESS;Database= My Database;Trusted_Connection=True;";
                conn.Open();
                // Create the command
                SqlCommand command = new SqlCommand("SELECT * FROM Client", conn);
                // Add the parameters
                command.Parameters.Add(new SqlParameter("0", 1));

                //-- How To Display Data Results --

                // Create an SqlDataReader object and read data from the command
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("FirstColumn Second Column Third Column \t Forth Column \t Fifth Column \t Sixth Column");
                    // while there is another data present
                    while (reader.Read())
                    {
                        // write & Display data 
                        Console.WriteLine(String.Format("{0} \t | {1} \t | {2} \t | {3}\t | {4}\t | {5} ",
                            reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]));
                    }
                }
                Console.WriteLine("Data displayed! Now press enter to move to the next section!");
                Console.ReadLine();

                Console.Clear();
                conn.Close();


                //This code is used to add the data to the table using SQL Command (INSERT INTO)
                conn.Open();
                /*Create the command, to insert the data into the Table
                  the @ symbol means it's a parameter that we will assign a value later 
                 */
                SqlCommand insertCommand = new SqlCommand("INSERT INTO Activity (stationName, activityName, prix) VALUES (@stationName, @activityName, @prix)", conn);
                insertCommand.Parameters.Add(new SqlParameter("stationName", "Venusa"));
                insertCommand.Parameters.Add(new SqlParameter("activityName", "Kayak"));
                insertCommand.Parameters.Add(new SqlParameter("prix", 80));
                // Execute the command, and display the values of the affected columns 
                // the command executed 
                Console.WriteLine("Commands executed! Total rows affected are " + insertCommand.ExecuteNonQuery());
                Console.WriteLine("Done! Press enter to move to the next step");
                Console.ReadLine();
                Console.Clear();
                conn.Close();




                //This code is used to select records and then to update them 
                conn.Open();
                // Create the command
                SqlCommand updateCommand = new SqlCommand("Update Client set city=@city,region=@region where Id=@Id", conn);
                updateCommand.Parameters.Add(new SqlParameter("id", 20));
                updateCommand.Parameters.Add(new SqlParameter("city", "LA"));
                updateCommand.Parameters.Add(new SqlParameter("region", "Australia"));
                // Execute the command, and display the values of the affected columns 
                // the command executed
                Console.WriteLine("Commands executed! Total rows affected are " + updateCommand.ExecuteNonQuery());
                Console.WriteLine("Done! Press enter to move to the next step");
                Console.ReadLine();
                Console.Clear();
                conn.Close();


                //This code is used to select records and then to delete them 
                conn.Open();
                // Create the command
                SqlCommand deleteCommand = new SqlCommand("Delete from Activity where stationName=@stationName AND activityName=@activityName", conn);
                deleteCommand.Parameters.Add(new SqlParameter("stationName", "Venusa"));
                deleteCommand.Parameters.Add(new SqlParameter("activityName", "Kayak"));
                // Execute the command, and display the values of the affected columns 
                // the command executed
                Console.WriteLine("Commands executed! Total rows affected are " + deleteCommand.ExecuteNonQuery());
                Console.WriteLine("Done! Press enter to move to the next step");
                Console.ReadLine();
                Console.Clear();
                conn.Close();

            }

        }
    }
}