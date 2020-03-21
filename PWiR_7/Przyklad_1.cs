using System;
using System.Threading;

namespace PWiR_7
{
    public class Przyklad_1
    {
        [ThreadStatic]
        static int _licznik = 0;

        public static void RUN()
        {
            //RunA();
            RunB();
            Console.ReadLine();
        }
        static void RunA()
        {
            //licznik = 10;    
            ParameterizedThreadStart metodaWatku = (object parametr) =>
            {
                Interlocked.Increment(ref _licznik);   // licznik++
                Console.WriteLine("Wątek: {0} Licznik: {1} Parametr: {2}",
                    Thread.CurrentThread.ManagedThreadId,
                    _licznik.ToString(), parametr);
            };
            Thread[] watek = new Thread[10];
            for (int i = 0; i < 10; ++i)
            {
                watek[i] = new Thread(metodaWatku);
                watek[i].Start(i);
            }
        }
        static void RunB()
        {
            //licznik = 10;   
            WaitCallback metodaWatku = (object parametr) =>
            {
                Interlocked.Increment(ref _licznik);   // licznik++
                Console.WriteLine("Wątek: {0} Licznik: {1} Parametr: {2}",
                    Thread.CurrentThread.ManagedThreadId,
                    _licznik.ToString(), parametr);
            };
            for (int i = 0; i < 10; ++i)
                ThreadPool.QueueUserWorkItem(metodaWatku, i);
        }
    }
}
