using System;
using Microsoft.ServiceModel.WebSockets;

namespace OsuExam.WcfWebSocketListener
{
    class Program
    {
   
        static void Main(string[] args)
        {
            var host = new WebSocketHost<MyWebSocketService>(new Uri("http://localhost:80/WebSocket"));
            //var bindingSsl = WebSocketHost.CreateWebSocketBinding(true);
            var endpoint = host.AddWebSocketEndpoint(Int32.MaxValue, Int32.MaxValue, null);
            
            host.Open();

            Console.ReadLine();

            host.Close();
        }
    }
}

