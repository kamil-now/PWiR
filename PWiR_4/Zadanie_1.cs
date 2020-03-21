using System;
using System.Threading;

namespace PWiR_4
{
    public class Zadanie_1
    {
        static readonly object _lck = new object();
        static int _bilans = 500;
        public static void RUN()
        {
            Thread t1 = new Thread(new ThreadStart(Dodaj));
            Thread t2 = new Thread(new ThreadStart(Odejmij));
            t2.Start();
            t1.Start();

            Console.ReadKey();
        }
        static void Odejmij()
        {
            for (int i = 0; i < 20; i++)
            {
                Monitor.Enter(_lck);
                if (_bilans <= 0)
                {
                    Monitor.Wait(_lck);
                }
                _bilans -= 100;
                Console.WriteLine($"Po odjęciu: {_bilans}");
                Monitor.Exit(_lck);
            }
        }
        static void Dodaj()
        {
            for (int i = 0; i < 20; i++)
            {
                Monitor.Enter(_lck);
                _bilans += 100;
                Console.WriteLine($"Po dodaniu: {_bilans}");
                Monitor.Exit(_lck);
            }
        }
    }
}
