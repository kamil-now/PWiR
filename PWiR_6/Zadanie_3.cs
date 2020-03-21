using System;
using System.Threading;

namespace PWiR_6
{
    public class Zadanie_3
    {
        static int _n = 0;
        static readonly Random _rnd = new Random();
        static Basen _malyBasen = new Basen("m", 5);
        static Basen _duzyBasen = new Basen("d", 10);
        public static void RUN()
        {
            for (int i = 1; i <= 25; i++)
            {
                var th = new Thread(() =>
                {
                    var m = false;
                    var d = false;
                    while (!m || !d)
                    {
                        if (!m)
                        {
                            m = _malyBasen.Plywaj();
                        }
                        if (!d)
                        {
                            d = _duzyBasen.Plywaj();
                        }
                    }
                    Console.WriteLine($"{Thread.CurrentThread.Name,2} koniec");
                })
                {
                    Name = $"{i}"
                };
                th.Start();
            }
            Console.ReadKey();
        }
        class Basen
        {
            Semaphore _sem;
            string _nazwa;
            public Basen(string nazwa, int max)
            {
                _nazwa = nazwa;
                _sem = new Semaphore(max, max);
            }
            public bool Plywaj()
            {
                if (!_sem.WaitOne(0))
                {
                    return false;
                }
                Console.WriteLine($"{Interlocked.Increment(ref _n),2}: {Thread.CurrentThread.Name,2} w {_nazwa}");
                Thread.Sleep(_rnd.Next(100, 501));
                _sem.Release();
                return true;
            }
        }
    }
}
