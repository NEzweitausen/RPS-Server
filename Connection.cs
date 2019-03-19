using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RPS_Server
{
    class Connection
    {
        private TcpClient client;

        public Connection(TcpClient client)
        {
            this.client = client;


            var thread = new Thread(Run);
            thread.IsBackground = true;
            thread.Start();
        }


        public void Run()
        {
            Console.WriteLine("Verbunden mit Client " + client.Client.RemoteEndPoint);
            client.NoDelay = true; //Verzögerung Deaktiviert wenn Sende und Empfangspuffer nicht voll
            client.LingerState = new LingerOption(true, 5); //Ruft Informationen zum Nachlaufzustand des zugeordneten Sockets ab oder legt sie fest.


            var stream = client.GetStream();
            var reader = new StreamReader(stream, Encoding.Default);
            var writer = new StreamWriter(stream, Encoding.Default);

            writer.AutoFlush = true;

            Eingabe e = new Eingabe(reader, writer);
            Game game = new Game(e,writer,"Spieler1","Spieler2");


        }
    }
}
