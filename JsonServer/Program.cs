﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonServer
{
    class Program
    {
        private const int port = 10003;
        static void Main(string[] args)
        {
            Server server = new Server(port);
            server.Start();

            Console.ReadLine();
        }
    }
}
