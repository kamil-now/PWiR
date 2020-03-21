using System;
using System.Threading;

namespace PWiR_3
{
    public class Przyklad_3
    {
        public static void RUN()
        {
            Thread t = new Thread(new ThreadStart(CosRobi));
            t.Start();
            Console.WriteLine("Ciąg dalszy programu...");
            while (!t.IsAlive) ;  // Wstrzymanie wątku głównego do czasu faktycznego uruchomienia wątku drugiego
            Thread.Sleep(1);    // Blokowanie aktualnego wątku (main) na określony czas,
                                // aby pozwolić metodzie CosRobi () na działanie przez pewien czas
            t.Abort();          // Zatrzymanie wątku drugiego
            Console.ReadKey();
        }
        static void CosRobi()
        {
            try
            {
                while (true) Console.WriteLine("Coś się robi...");
            }
            catch (ThreadAbortException ex)    // ten wyjątek zostanie złapany po wykonaniu Abort()
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
