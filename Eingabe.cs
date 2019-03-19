using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS_Server
{
    class Eingabe
    {
        private StreamReader reader;
        private StreamWriter writer;

        public Eingabe(StreamReader reader, StreamWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public double EingabeDouble()
        {
            double parameter = 0;
            bool gültig = false;
            while (gültig == false)
            {
                try
                {
                    parameter = double.Parse(reader.ReadLine());
                }
                catch
                {
                    writer.WriteLine("Diese Eingabe ist ungültig!");
                }
                if (parameter != 0) gültig = true;
            }

            return parameter;
        }

        public int EingabeInt()
        {
            int parameter = 0;
            bool gültig = false;
            while (gültig == false)
            {
                try
                {
                    parameter = int.Parse(reader.ReadLine());
                }
                catch
                {
                    writer.WriteLine("Diese Eingabe ist ungültig!");
                }
                if (parameter != 0) gültig = true;
            }

            return parameter;
        }

        public string EingabeString()
        {
            bool gültig = false;
            string parameter = " ";

            while (gültig == false)
            {
                parameter = reader.ReadLine();
                if (parameter != " " || parameter != "") gültig = true;
            }

            return parameter;
        }
    }
}
