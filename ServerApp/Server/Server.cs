using System;
using System.Net;
using System.Text;
using System.Text.Json;
using ServerApp.Controllers;

namespace ServerApp.Server
{
    public class HttpServer
    {
        private readonly UserController _controller = new();

        public void Start()
        {
            HttpListener listener = new();
            listener.Prefixes.Add("http://localhost:8080/");
            listener.Start();
            Console.WriteLine("Server is running at http://localhost:8080");

            while (true)
            {
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;

                if (request.Url.AbsolutePath == "/users" && request.HttpMethod == "GET")
                {
                    var users = _controller.GetAllUsers();
                    string json = JsonSerializer.Serialize(users);
                    byte[] buffer = Encoding.UTF8.GetBytes(json);
                    response.ContentLength64 = buffer.Length;
                    response.OutputStream.Write(buffer, 0, buffer.Length);
                }
                else
                {
                    response.StatusCode = 404;
                }

                response.OutputStream.Close();
            }
        }
    }
}
