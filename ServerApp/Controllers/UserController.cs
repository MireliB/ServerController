using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ServerApp.Models;

namespace ServerApp.Controllers
{
    public class UserController
    {
        private readonly string _connectionString = "Server=localhost;Database=MyDatabase;Trusted_Connection=True;";

        public void AddUser(User user)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var cmd = new SqlCommand("INSERT INTO Users (Name, Email, Password) VALUES (@Name, @Email, @Password)", connection);
            cmd.Parameters.AddWithValue("@Name", user.Name);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.ExecuteNonQuery();
        }

        public User? GetUser(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var cmd = new SqlCommand("SELECT * FROM Users WHERE ID = @ID", connection);
            cmd.Parameters.AddWithValue("@ID", id);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new User
                {
                    ID = (int)reader["ID"],
                    Name = (string)reader["Name"],
                    Email = (string)reader["Email"],
                    Password = (string)reader["Password"]
                };
            }
            return null;
        }

        public List<User> GetAllUsers()
        {
            var users = new List<User>();
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var cmd = new SqlCommand("SELECT * FROM Users", connection);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                users.Add(new User
                {
                    ID = (int)reader["ID"],
                    Name = (string)reader["Name"],
                    Email = (string)reader["Email"],
                    Password = (string)reader["Password"]
                });
            }
            return users;
        }

        public void UpdateUser(User user)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var cmd = new SqlCommand("UPDATE Users SET Name = @Name, Email = @Email, Password = @Password WHERE ID = @ID", connection);
            cmd.Parameters.AddWithValue("@Name", user.Name);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@ID", user.ID);
            cmd.ExecuteNonQuery();
        }

        public void DeleteUser(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var cmd = new SqlCommand("DELETE FROM Users WHERE ID = @ID", connection);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();
        }
    }
}
