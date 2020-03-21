using System;
using System.Threading;

namespace PWiR_3
{
    public class Przyklad_2
    {
        public static void RUN()
        {
            Thread t = new Thread(new ThreadStart(CosRobi));
            t.Start();

            Console.WriteLine("Ciąg dalszy programu...");
            Console.ReadKey();
        }

        static void CosRobi()
        {
            int x = 0;
            while (x < 10)
            {
                Console.WriteLine("Coś się robi..."); x++;
            }
        }
    }
}
