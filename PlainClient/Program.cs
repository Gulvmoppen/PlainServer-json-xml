using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainClient
{
    class Program
    {
        private const int port = 10001;
        static void Main(string[] args)
        {
            Client client = new Client(port);
            client.Start();

            Console.ReadLine();
        }
    }
}
