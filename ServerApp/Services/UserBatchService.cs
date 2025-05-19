using System;
using ServerApp.Controllers;
using ServerApp.Models;

namespace ServerApp.Services
{
    public class UserBatchService
    {
        private readonly UserController _controller = new();

        public void Process()
        {
            var users = _controller.GetAllUsers();
            Console.WriteLine($"Processing {users.Count} users...");

            foreach (var user in users)
            {
                Console.WriteLine($"[BATCH] Sending email to {user.Email}");
            }

            Console.WriteLine("Batch processing complete.");
        }
    }
}
