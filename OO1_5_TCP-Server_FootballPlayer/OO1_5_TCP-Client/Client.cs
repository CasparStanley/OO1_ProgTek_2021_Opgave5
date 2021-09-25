using OO1_Opgave1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace OO1_5_TCP_Client
{
    class Client
    {
        public void Start()
        {
            Console.WriteLine("COMMANDS:\n'HentAlle', Enter x2   - Henter Alle Objekter" +
                              "\n'Hent', Enter, '<ID>', Enter   - Henter et specifikt objekt" +
                              "\n'Gem', Enter, '<JSON Objekt>' (eks. 'ID':123, ...), Enter   - Gemmer et objekt" +
                              "\n\n");

            TcpClient socket = new TcpClient("localhost", 2121);

            using (StreamReader sr = new StreamReader(socket.GetStream()))
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            {
                sw.AutoFlush = true;

                string output1 = Console.ReadLine();
                sw.WriteLine(output1);

                string output2 = Console.ReadLine();
                sw.WriteLine(output2);

                string line1 = sr.ReadLine();
                Console.WriteLine(line1);

                string line2 = sr.ReadLine();
                Console.WriteLine(line2);
            }
        }
    }
}
