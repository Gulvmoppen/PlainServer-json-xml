using System;
using System.IO;
using System.Net.Sockets;
using System.Xml.Serialization;
using ModelLib;

namespace XmlClient
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
            Car car = new Car("Tesla", "Blue", "XMLCar23");

            using (TcpClient cSocket = new TcpClient("localhost", port))
            using (Stream stream = cSocket.GetStream())
            using (StreamWriter toServer = new StreamWriter(stream))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Car));

                StringWriter sw = new StringWriter();
                serializer.Serialize(sw, car);
                Console.WriteLine($"XML size {sw.ToString().Length}\n{sw.ToString()} ");

                serializer.Serialize(toServer, car);
                toServer.Flush();
            }
        }
    }
}