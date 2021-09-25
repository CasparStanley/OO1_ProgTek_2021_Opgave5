using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading;
using OO1_5_TCP_Server_FootballPlayer;

namespace OO1_5_TCP_Server
{
    class Server
    {
        public Server() { }

        public void Start(int port)
        {
            TcpListener listener = new TcpListener(port);
            listener.Start();

            // While loop to handle more than a single client
            while(true)
            {
                TcpClient socket = listener.AcceptTcpClient();

                // Task to handle concurrent clients, on separate threads
                Task.Run(() =>
                {
                    // Doing this to ensure loop is not continued before DoClient is done
                    TcpClient tempSocket = socket;
                    DoClient(tempSocket);
                }
                );
            }
        }

        private void DoClient(TcpClient socket)
        {
            // "using" makes sure it is only opened here, and automatically closed when done
            using (StreamReader sr = new StreamReader(socket.GetStream()))
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            {
                // SETUP ------------------------------------------------------------------------------------- SETUP
                string commandOne = sr.ReadLine();
                string commandTwo = sr.ReadLine();

                // INPUT ------------------------------------------------------------------------------------- INPUT
                if (commandOne.ToLower() == "hentalle")
                {
                    string output = GetAll();
                    sw.WriteLine(output);
                    Console.WriteLine(output);
                }

                else if (commandOne.ToLower() == "hent")
                {
                    string output = Get(commandTwo);
                    sw.WriteLine(output);
                    Console.WriteLine(output);
                }

                else if (commandOne.ToLower() == "gem")
                {
                    string output = Save(commandTwo);
                    sw.WriteLine(output);
                    Console.WriteLine(output);

                    Console.WriteLine("\nGemmer Fodboldspiller\n");

                    if (commandTwo.ToLower() == "0")
                    {
                        Console.WriteLine("\nGemmer Fodboldspiller 0\n");
                    }
                }

                //
                //Console.WriteLine($"Received: {player.ToString()}");
            }

            socket?.Close();
        }

        private string GetAll()
        {
            string allPlayers = JsonSerializer.Serialize(Program.players);

            Console.WriteLine($"Henter Alle Fodboldspillere:");

            // Split JSON into different lines
            // - Works perfectly for the server,
            // but sw.WriteLine only returns the first two FootballPlayers !WHEN RUNNING IN VISUAL STUDIO!
            // It works fine in SocketTest. Very weird.
            // You can try it if you like: 

            /*
            string output = "";
            foreach (string s in SplitString(allPlayers, "},{"))
            {
                output += s + "\n";
            }

            return output;
            */

            return allPlayers;
        }

        private string Get(string id_string)
        {
            int id;
            string errorMsg = "\nID var ikke et validt nummer. Afbryder.\n";

            Console.WriteLine("\nHenter specifik Fodboldspiller...\n");

            try
            {
                id = Int32.Parse(id_string);

                return JsonSerializer.Serialize(Program.players.Find(i => i.Id == id));
            }
            catch
            {
                return errorMsg;
            }
        }

        private string Save(string commandTwo)
        {
            string errorMsg = "\nKommandoen var ikke formateret korrekt. Fejlet.\n";

            Console.WriteLine("\nGemmer Fodboldspiller\n");

            try
            {
                Program.players.Add(JsonSerializer.Deserialize<FootballPlayer>(commandTwo));
                return "Success!";
            }
            catch
            {
                return errorMsg;
            }
        }

        private string[] SplitString(string input, string delimiter)
        {
            return input.Split(delimiter);
        }
    }
}
