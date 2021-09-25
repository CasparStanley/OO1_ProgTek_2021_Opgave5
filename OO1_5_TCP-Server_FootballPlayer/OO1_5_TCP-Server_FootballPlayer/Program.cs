using OO1_Opgave1;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OO1_5_TCP_Server
{
    class Program
    {
        public static List<FootballPlayer> players = new List<FootballPlayer>()
        {
            new FootballPlayer(0, "Jesper Groenkjaer", 50000, 10),
            new FootballPlayer(1, "Jesper Kristiansen", 20000, 1),
            new FootballPlayer(2, "Kasper Schmeicel", 100000, 9),
            new FootballPlayer(3, "Fodboldspiller Fire", 40000, 99),
            new FootballPlayer(4, "En mere", 59000, 69),
        };

        static void Main()
        {
            Server server = new Server();
            // Starter serveren på den givne port
            server.Start(2121);
        }
    }
}
