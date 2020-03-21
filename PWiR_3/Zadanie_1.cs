using System;
using System.Threading;

namespace PWiR_3
{
    public class Zadanie_1
    {
        public static void RUN()
        {
            RunA();
            RunB();

            Console.ReadKey();
        }
        static void RunA()
        {
            Thread t = new Thread(new ThreadStart(OdliczajBiale));
            t.Start();

            OdliczajCzerowone();
        }
        static void RunB()
        {
            OdliczajBiale();
            OdliczajCzerowone();
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
