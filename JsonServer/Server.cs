using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using ModelLib;
using Newtonsoft.Json;

namespace JsonServer
{
    internal class Server
    {
        private int port;

        public Server(int port)
        {
            this.port = port;
        }

        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Any, port);
            server.Start();

            while (true)
            {
                TcpClient clientSocket = server.AcceptTcpClient();
                Task.Run(() =>
                {
                    TcpClient socket = clientSocket;
                    DoClient(socket);
                });
            }
        }

        private void DoClient(TcpClient socket)
        {
            using (NetworkStream stream = socket.GetStream())
            using (StreamReader fromClient = new StreamReader(stream))
            {
                String strFromClient = fromClient.ReadLine();
                Console.WriteLine($"From Client text : {strFromClient}");

                Car car = JsonConvert.DeserializeObject<Car>(strFromClient);
                Console.WriteLine($"From Client as car obj : {car}");


            }
        }
    }
}