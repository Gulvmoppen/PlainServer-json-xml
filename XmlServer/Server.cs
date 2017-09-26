using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ModelLib;

namespace XmlServer
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
                XmlSerializer serializer = new XmlSerializer(typeof(Car));

                Car carCopy = (Car)serializer.Deserialize(fromClient);
                Console.WriteLine($"From Client as Car object : {carCopy}");
            }
        }
    }
}