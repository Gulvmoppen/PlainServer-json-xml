using System;
using System.IO;
using System.Net.Sockets;
using ModelLib;
using Newtonsoft.Json;

namespace JsonClient
{
    internal class Client
    {
        private int port;

        public Client(int port)
        {
            this.port = port;
        }

        public void Start()
        {
            Car car = new Car("Tesla", "Green", "ab12345");

            using (TcpClient cSocket = new TcpClient("localhost", port))
            using (Stream stream = cSocket.GetStream())
            using (StreamWriter toServer = new StreamWriter(stream))
            {
                String jsonStr = JsonConvert.SerializeObject(car);
                Console.WriteLine($"Client json string: {jsonStr} and size:: {jsonStr.Length}");

                toServer.WriteLine(jsonStr);
                toServer.Flush();
            }

        }
    }
}