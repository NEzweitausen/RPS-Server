using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RPS_Server
{
    class Start
    {
        public Start()
        {
            VerbindungenAufbauen();
        }

        private void VerbindungenAufbauen()
        {
            var server = new TcpListener(IPAddress.Any, 4712);
            server.Start();
            Console.WriteLine("Der Schere-Stein-Papier-Server ist bereit.");

            while (true)
            {
                var client = server.AcceptTcpClient();
                Connection connection = new Connection(client);
            }
        }

    }
}
