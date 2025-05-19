using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Server=localhost;Database=MyDatabase;Trusted_Connection=True;";

        using var connection = new SqlConnection(connectionString);

        try
        {
            connection.Open();
            Console.WriteLine("✅ Connection to SQL Server succeeded!");

            string query = "SELECT COUNT(*) FROM Users";
            SqlCommand command = new SqlCommand(query, connection);
            int count = (int)command.ExecuteScalar();

            Console.WriteLine($"📊 Number of users in table: {count}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("❌ Failed to connect to database:");
            Console.WriteLine(ex.Message);

            Console.ReadLine();
        }
    }
}
