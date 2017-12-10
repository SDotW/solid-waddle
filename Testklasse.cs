using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoReservierung
{
    public class Testklasse
    {
      
           public static void Main(string[] args)
            {

            #region test1
            //Test 1: 
            //1. erzeuge Saal mit std-Konstruktor. 
            //2. Belege 17 Sitze nach Random 
            //3. Belege Platz 5 in Reihe 7.
            //4. gib den Status aus.
            //5. suche 9 zusammenhängende Reservierbare Plätze.
            // suche 4
            //suche 7
            // suche 9
            //6. Gib den Status noch einmal aus.

            Kinosaal saal1 = new Kinosaal();
                saal1.printStatus();
                saal1.platzBelegenZufall(17);
                saal1.platzBelegenDirekt(7, 5);
                saal1.printStatus();

                saal1.platzBelegenInFolge(9);
                saal1.platzBelegenInFolge(4);
                saal1.platzBelegenInFolge(7);
                saal1.platzBelegenInFolge(9);
                saal1.printStatus();
            #endregion

            #region test2
            //Test 2: 
            //1. erzeuge Saal mit 20 Plätzen und 35 Reihen. 
            //2. Belege 17 Sitze nach Random 
            //3. 
            //  a) Belege Platz 5 in Reihe 7.
            //  b) Belege Platz 7 in Reihe 7.
            //  c) Belege Platz 11 in Reihe 11.
            //4. gib den Status aus.
            //5. suche 9 zusammenhängende Reservierbare Plätze.
            // suche 4
            //suche 7
            // suche 9

            //6. Gib den Status noch einmal aus.

            Console.WriteLine();
                Console.WriteLine("========================TEST 2======================");

                Kinosaal saal2 = new Kinosaal(20, 35);
                saal2.platzBelegenZufall(17);
                saal2.platzBelegenDirekt(5, 7);
                saal2.platzBelegenDirekt(7, 7);
                saal2.platzBelegenDirekt(11, 11);
                saal2.printStatus();
                saal2.platzBelegenInFolge(9);
                saal2.platzBelegenInFolge(4);
                saal2.platzBelegenInFolge(7);
                saal2.platzBelegenInFolge(9);
                saal2.printStatus();
            #endregion
        }
    }
    }

