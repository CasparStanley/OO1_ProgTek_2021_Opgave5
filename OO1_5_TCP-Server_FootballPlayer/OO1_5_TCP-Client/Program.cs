using System;

namespace OO1_5_TCP_Client
{
    class Program
    {
        static void Main()
        {
            Client client = new Client();
            client.Start();

            Console.ReadLine();
        }
    }
}
