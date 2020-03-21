using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace PWiR_6
{
    public class Zadanie_1
    {
        static readonly Random _rnd = new Random();
        static readonly object _lck = new object();
        static string _pytanie;
        public static void RUN()
        {
            Thread t1 = new Thread(new ThreadStart(Odpowiedz));
            Thread t2 = new Thread(new ThreadStart(Zapytaj));
            t2.Start();
            t1.Start();

            Console.ReadKey();
        }
        static void Zapytaj()
        {
            foreach (var pytanie in Enumerable.Range(1, 5).Select(x => $"{x}?"))
            {
                Thread.Sleep(_rnd.Next(100, 501));
                Monitor.Enter(_lck);
                _pytanie = pytanie;
                Console.WriteLine(pytanie);
                Monitor.Pulse(_lck);
                Monitor.Exit(_lck);
            }
        }
        static void Odpowiedz()
        {
            var tab = new Queue<string>(Enumerable.Range(1, 5).Select(x => $"{x}!"));
            while (tab.Count > 0)
            {
                Monitor.Enter(_lck);
                if (_pytanie is null)
                {
                    Monitor.Wait(_lck);
                }
                Console.WriteLine(tab.Dequeue());
                _pytanie = null;
                Monitor.Exit(_lck);
            }
        }
    }
}
