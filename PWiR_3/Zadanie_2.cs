using System;
using System.Threading;

namespace PWiR_3
{
    public class Zadanie_2
    {
        public static void RUN()
        {
            Thread t = new Thread(new ParameterizedThreadStart(Odliczaj));
            t.Start(ConsoleColor.White);

            Odliczaj(ConsoleColor.Red);

            Console.ReadKey();
        }
        static void Odliczaj(object color)
        {
            for (int i = 1000; i > 0; i--)
            {
                Console.ForegroundColor = (ConsoleColor)color;
                Console.Write(i.ToString() + " ");
            }
        }
    }
}
