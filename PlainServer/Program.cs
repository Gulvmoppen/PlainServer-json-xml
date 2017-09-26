using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainServer
{
    class Program
    {
        private const int port = 10001;
        static void Main(string[] args)
        {
            Server server = new Server(port);
            server.Start();

            Console.ReadLine();
        }
    }
}
