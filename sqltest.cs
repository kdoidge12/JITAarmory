using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace sqltest
{
    class Program
    {
        static void Main(string[] args)
        {

            try 
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "armory.database.windows.net";
                builder.UserID = "jita";
                builder.Password = "password1!";
                builder.InitialCatalog = "destinyArmory";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");

                    connection.Open();       
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT * FROM [dbo].[num]");
                    String sql = sb.ToString();
                    Console.WriteLine(sql);

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        Console.WriteLine("=========================================\n");
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine("=========================================\n");
                            while (reader.Read())
                            {
                                Console.WriteLine("=========================================\n");
                                Console.WriteLine("{0}", reader.GetInt32(0));
                            }
                        }
                    }                    
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
        

        }
    }
}
