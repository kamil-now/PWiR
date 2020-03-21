using System;
using System.Threading;

namespace PWiR_3
{
    public class Przyklad_4
    {
        public static void RUN()
        {
            Thread t = new Thread(new ThreadStart(OdliczajBiale));   // definicja wątku
            t.Start();

            OdliczajCzerowone();    // Wywolanie metody odliczajacej w pierwszym watku

            Console.ReadKey();
        }

        static void OdliczajBiale()
        {
            for (int i = 1000; i > 0; i--)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(i.ToString() + " ");
            }
        }

        static void OdliczajCzerowone()
        {
            for (int i = 1000; i > 0; i--)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(i.ToString() + " ");
            }
        }
    }
}
