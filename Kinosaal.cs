using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoReservierung
{
    public class Kinosaal
    {
        #region fields, properties, constructors
        private bool[,] saal;
        private int frei;
        private int belegt;

        public Kinosaal(int reihe, int platz)
        {
            this.saal = new bool[reihe, platz];
            this.frei = this.saal.Length;
            this.belegt = 0;
        }

        public Kinosaal()
        {
            this.saal = new bool[20, 10];
            this.frei = this.saal.Length;
            this.belegt = 0;
        }
        #endregion

        #region Methoden "Anzahl"
        /// <summary>
        /// Gibt Summe der vorhandenen Sitzplätze aus.
        /// </summary>
        /// <returns>int</returns>
        public int AnzahlPlaetze()
        {
            return saal.Length;
        }

        /// <summary>
        /// Gibt Anzahl der Reihen des Kinosaals aus.
        /// </summary>
        /// <returns></returns>
        public int AnzahlReihen()
        {
            return saal.GetLength(0);
        }
        /// <summary>
        /// Gibt Anzahl der Sitze pro Reihe aus.
        /// </summary>
        /// <returns></returns>
        public int AnzahlPlatzProReihe()
        {
            return saal.GetLength(1);
        }
        /// <summary>
        /// Zählt die Anzahl der freien Plätze. 
        /// </summary>
        /// <returns></returns>
        public int AnzahlPlatzFrei()
        {
            int unreserviert = 0;

            for (int reihe = 0; reihe < this.AnzahlReihen(); reihe++)
            {

                for (int sitz = 0; sitz < this.AnzahlPlatzProReihe(); sitz++)
                {
                    if (this.saal[reihe, sitz] == false)
                    {
                        unreserviert++;
                    }
                }
            }
            return unreserviert;
        }
        /// <summary>
        /// Zählt die Anzahl der belegten Plätze. 
        /// </summary>
        /// <returns></returns>
        public int AnzahlPlatzBelegt()
        {
            int reserviert = 0;

            for (int reihe = 0; reihe < this.AnzahlReihen(); reihe++)
            {

                for (int sitz = 0; sitz < this.AnzahlPlatzProReihe(); sitz++)
                {
                    if (this.saal[reihe, sitz] == true)
                    {
                        reserviert++;
                    }
                }

            }
            return reserviert;
        }
        #endregion

        #region Methoden "Plätze belegen". 
        /// <summary>
        /// Belegt eine bestimmte Anzahl von Plätzen nach Zufall.
        /// </summary>
        /// <param name="anzahl"></param>
        public void platzBelegenZufall(int anzahl)
        {
            if (this.frei == 0)
            {
                Console.WriteLine("Der Saal ist voll!");
                return;
            }

            Random random = new Random();
            int pl, rh;
            for (int i = 0; i < anzahl; i++)
            {
                pl = random.Next(0, this.saal.GetLength(1) - 1);
                rh = random.Next(0, this.AnzahlReihen() - 1);

                if (this.saal[rh, pl] == false)
                {
                    this.platzBelegenDirekt(rh, pl);
                }
                else i--;
            }
        }
        /// <summary>
        /// Belegt einen Platz direkt.
        /// </summary>
        /// <param name="reihe"></param>
        /// <param name="platz"></param>
        public void platzBelegenDirekt(int reihe, int platz)
        {
            if(reihe <= 0 || platz <= 0)
            {
                return;
            }

            reihe++;
            platz++;

            if (this.saal[reihe, platz] == false)
            {
                this.saal[reihe, platz] = true;
                this.belegt++;
                this.frei--;
                Console.WriteLine("Belegt: Platz: " + platz + " in Reihe: " + reihe);
            }
            else { Console.WriteLine("Platz ist schon besetzt."); }
        }
        /// <summary>
        /// Belegt eine Folge von Plätze, sofern noch genug Plätze vorhanden sind.
        /// </summary>
        /// <param name="anzahl"></param>
        public void platzBelegenInFolge(int anzahl)
        {

            if (anzahl <= 0) { return; }

            int platzZaehler = 0;
            int platzIndex = 0;

            if (this.frei == 0)
            {
                Console.WriteLine("Der Saal ist voll!");
                return;
            }

            for (int reihenCheck = 0; reihenCheck < this.AnzahlReihen(); reihenCheck++)
            {

                platzIndex = 0;
                platzZaehler = 0;

                for (int platzCheck = 0; platzCheck < this.AnzahlPlatzProReihe(); platzCheck++)
                {

                    if (this.saal[reihenCheck, platzCheck] == false)
                    {
                        platzZaehler++;
                    }

                    if (platzZaehler == anzahl)
                    {
                        break;
                    }
                }

                if (platzZaehler == anzahl)
                {

                    Console.WriteLine(anzahl + " Sitze gefunden in Reihe " + (reihenCheck+1));
                    Console.WriteLine("Reserviere " + anzahl + " Sitze...");

                    for (int beleger = 0; beleger < anzahl; beleger++)
                    {
                        Console.WriteLine("reihenCheck: " + (reihenCheck+1) + " platzIndex: " + (platzIndex+1));
                        this.platzBelegenDirekt(reihenCheck, platzIndex);
                        platzIndex++;
                    }
                }

                else continue;

            }

            if (platzZaehler < anzahl) { Console.WriteLine("Vorgang nicht möglich."); }
        }
        #endregion

        #region Methoden "Statusanzeigen"
        /// <summary>
        /// Liefert einen Statusbericht über den Kinosaal. 
        /// </summary>
        public void printStatus()
        {

            Console.WriteLine("::Drucke Status::");
            Console.WriteLine("Sitzplätze: " + this.AnzahlPlaetze());
            Console.WriteLine("Belegte Plätze (Liste) : " + this.belegt);
            Console.WriteLine("Belegte Plätze (System): " + this.AnzahlPlatzBelegt());
            Console.WriteLine("Freie Plätze   (Liste) : " + this.frei);
            Console.WriteLine("Freie Plätze  (System) : " + this.AnzahlPlatzFrei());
            Console.WriteLine("===========================");
            Console.WriteLine("Deatailierte Belegungsliste: ");
            Console.WriteLine();

            for (int reihe = 0; reihe < this.AnzahlReihen(); reihe++)
            {

                for (int sitz = 0; sitz < this.AnzahlPlatzProReihe(); sitz++)
                {
                    if (this.saal[reihe, sitz])
                    {
                        Console.WriteLine("Reihe " + (reihe+1) + ", Sitzplatz " + (sitz+1) + " ist belegt.");
                    }
                }
            }
        }
        #endregion

    }
}
