using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS_Server
{
    class Spieler
    {
        private string name;
        private int spielstand = 0;

        public string GETname()
        {
            return name;
        }

        public int GETspielstand()
        {
            return spielstand;
        }

        public void SETname(string Name)
        {
            name = Name;
        }

        public void SETspielstand(int Spielstand)
        {
            if (Spielstand > (spielstand + 1))
            {
                spielstand++;
            }

            spielstand = Spielstand;
        }
    }
}
