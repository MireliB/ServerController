using System;
using System.Data.SqlClient;
using ServerApp.Models;
using ServerApp.Controllers;

class Program
{
    static void Main()
    {
        var controller = new UserController();
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Choose Action:");
            Console.WriteLine("1. Show All Users");
            Console.WriteLine("2. Add User");
            Console.WriteLine("3. Delete User by ID");
            Console.WriteLine("4. Edit User by ID");
            Console.WriteLine("5. Exit");
            Console.Write("\nChoice: ");

            string choice = Console.ReadLine();
            Console.Clear();

            switch (choice)
            {
                case "1":
                    var users = controller.GetAllUsers();
                    Console.WriteLine("All Users:");
                    foreach (var u in users)
                    {
                        Console.WriteLine($"{u.ID}: {u.Name} - {u.Email}");
                    }
                    break;
                case "2":
                    Console.Write("Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Email: ");
                    string email = Console.ReadLine();

                    Console.Write("Password: ");
                    string password = Console.ReadLine();

                    var user = new User { Name = name, Email = email, Password = password };
                    controller.AddUser(user);

                    Console.WriteLine("\nUser Added Successfully");
                    break;


                case "3":
                    Console.Write("Enter User ID to Delete: ");
                    if (int.TryParse(Console.ReadLine(), out int deleteId))
                    {
                        controller.DeleteUser(deleteId);
                        Console.WriteLine("User Deleted");
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID");
                    }
                    break;

                case "4":
                    Console.Write("Enter User ID to Edit: ");
                    if (int.TryParse(Console.ReadLine(), out int editId))
                    {
                        var existingUser = controller.GetUser(editId);
                        if (existingUser == null)
                        {
                            Console.WriteLine("User not found.");
                            break;
                        }

                        Console.Write($"New Name (current: {existingUser.Name}): ");
                        string newName = Console.ReadLine();

                        Console.Write($"New Email (current: {existingUser.Email}): ");
                        string newEmail = Console.ReadLine();

                        Console.Write($"New Password (leave blank to keep current): ");
                        string newPassword = Console.ReadLine();

                        existingUser.Name = string.IsNullOrWhiteSpace(newName) ? existingUser.Name : newName;
                        existingUser.Email = string.IsNullOrWhiteSpace(newEmail) ? existingUser.Email : newEmail;
                        if (!string.IsNullOrWhiteSpace(newPassword))
                        {
                            existingUser.Password = newPassword;
                        }

                        controller.UpdateUser(existingUser);
                        Console.WriteLine("User Updated Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID");
                    }
                    break;

                case "5":
                    Console.WriteLine("Goodbye!");
                    running = false;
                    continue;

                default:
                    Console.WriteLine("Invalid Selection");
                    break;
            }

            Console.Write("\n Press [Enter] to return to menu or type 'exit' to quit: ");
            string returnChoice = Console.ReadLine();
            if (returnChoice?.ToLower() == "exit")
            {
                running = false;
            }
        }
    }
}
