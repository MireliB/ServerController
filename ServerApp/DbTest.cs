using System;
using System.Data.SqlClient;

public class DbTest
{
    public static void RunTest()
    {
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=MyDatabase;Trusted_Connection=True;";
        using var connection = new SqlConnection(connectionString);

        try
        {
            connection.Open();
            Console.WriteLine("Connected to SQL Server succeessfully");

            var command = new SqlCommand("SELECT COUNT(*) FROM Users", connection);
            var count = (int)command.ExecuteScalar();
            Console.WriteLine($"Number of users: {count}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error:");
            Console.WriteLine(ex.Message);
        }
    }
}
