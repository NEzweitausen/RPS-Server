using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS_Server
{
    enum Spielzüge { Schere, Stein, Papier };

    class Game
    {
        private Spieler spieler1 = new Spieler();
        private Spieler spieler2 = new Spieler();
        private Spielzüge Benutzer;
        private Spielzüge LastBenutzer;
        private Spielzüge Gegner;
        private Random random = new Random();
        private int CountMehrfacherSpielzug = 0;
        private int CountExit = 0;
        private StreamWriter writer;

        public Game(Eingabe e, StreamWriter writer, string spielername1, string spielername2) //Konstruktor
        {

            spieler1.SETname(spielername1);
            spieler2.SETname(spielername2);
            this.writer = writer;
            userinterface(e);
        }



        public void userinterface(Eingabe e)
        {

           
            bool running = true;


            do
            {
                writer.WriteLine("Sie haben folgende Optionen: \n1 - Schere \n2 - Stein \n3 - Papier\nGeben Sie ihren Zug ein");

                int ZugBenutzer = 0;
                bool ungültig = false;

                do
                {
                    ZugBenutzer = e.EingabeInt(); //Benutzereingabe
                    ungültig = false;

                    if (ZugBenutzer > 3 || ZugBenutzer < 1)
                    {
                        ungültig = true;
                        writer.WriteLine("Ungültiger Zug!");
                    }


                } while (ungültig == true);


                int ZugComputer = random.Next(1, 4); //Obere Grenze einen Wert über dem Zahlenbereich, Untere Grenze im Zahlenbereich !!!

                bool entschieden = Auswertung(ZugBenutzer, ZugComputer);

                if (entschieden == true)
                {
                    if (Gegner == Spielzüge.Papier) writer.WriteLine("1PAPIER"); //Spieler 1 ist der Gegner
                    if (Gegner == Spielzüge.Stein) writer.WriteLine("1STEIN");
                    if (Gegner == Spielzüge.Schere) writer.WriteLine("1SCHERE");

                    if (Benutzer == Spielzüge.Papier) writer.WriteLine("2PAPIER"); //Spieler zwei der jew Nutzer
                    if (Benutzer == Spielzüge.Stein) writer.WriteLine("2STEIN");
                    if (Benutzer == Spielzüge.Schere) writer.WriteLine("2SCHERE");

                }
                else
                {
                    writer.WriteLine("Unentschieden!");
                }

                writer.WriteLine("Der aktuelle Spielstand: \nComputer: " + spieler2.GETspielstand() + "\n" + spieler1.GETname() + ": " + spieler1.GETspielstand() + "\n");

                CountExit++;

                if (CountExit >= 8)
                {
                    writer.WriteLine("Geben Sie zum verlassen des Spiels das Schlüsselwort <exit> ein.");
                    if (e.EingabeString() == "exit") 
                    {
                        writer.WriteLine("EXIT");
                        running = false;
                    } 
                    CountExit = 0;
                }


            } while (running);


        }

        public Spielzüge Übersetzung(int ZugBenutzer)
        {
            Spielzüge Eingabe = new Spielzüge();

            if (ZugBenutzer == 1) Eingabe = Spielzüge.Schere;
            if (ZugBenutzer == 2) Eingabe = Spielzüge.Stein;
            if (ZugBenutzer == 3) Eingabe = Spielzüge.Papier;

            return Eingabe;
        }

        public bool Auswertung(int ZugBenutzer, int ZugGegner)
        {

            Benutzer = Übersetzung(ZugBenutzer);
            Gegner = Übersetzung(ZugGegner);


            if (LastBenutzer == Benutzer)
            {
                CountMehrfacherSpielzug++;

                if (CountMehrfacherSpielzug >= 3)
                {

                    writer.WriteLine("\nLangweilig... \nDer Computer hat deine Strategie entlarvt.\n");

                    if (Benutzer == Spielzüge.Schere) Gegner = Spielzüge.Stein;
                    if (Benutzer == Spielzüge.Stein) Gegner = Spielzüge.Papier;
                    if (Benutzer == Spielzüge.Papier) Gegner = Spielzüge.Schere;
                }


            }
            else
            {
                CountMehrfacherSpielzug = 0;
            }

            if (Benutzer == Gegner)
            {
                return false;
            }

            if (Benutzer == Spielzüge.Schere && Gegner == Spielzüge.Stein) spieler2.SETspielstand(spieler2.GETspielstand() + 1);
            if (Benutzer == Spielzüge.Schere && Gegner == Spielzüge.Papier) spieler1.SETspielstand(spieler1.GETspielstand() + 1);
            if (Benutzer == Spielzüge.Stein && Gegner == Spielzüge.Schere) spieler1.SETspielstand(spieler1.GETspielstand() + 1);
            if (Benutzer == Spielzüge.Stein && Gegner == Spielzüge.Papier) spieler2.SETspielstand(spieler2.GETspielstand() + 1);
            if (Benutzer == Spielzüge.Papier && Gegner == Spielzüge.Schere) spieler2.SETspielstand(spieler2.GETspielstand() + 1);
            if (Benutzer == Spielzüge.Papier && Gegner == Spielzüge.Stein) spieler1.SETspielstand(spieler1.GETspielstand() + 1);



            LastBenutzer = Benutzer;

            return true;

        }

    }
}
