using OO1_5_TCP_Server_FootballPlayer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OO1_5_TCP_Server
{
    class Program
    {
        static void Main()
        {
            Server server = new Server();
            // Starter serveren på den givne port
            server.Start(2121);
        }
    }
}
