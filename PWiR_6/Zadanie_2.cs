using System;
using System.Collections.Generic;
using System.Threading;

namespace PWiR_6
{
    public class Zadanie_2
    {
        static int _n = 0;
        [ThreadStatic]
        static int _suma = 0;
        static readonly int _ileSal = 4;
        static List<Sala> _sale = new List<Sala>();
        public static void RUN()
        {
            int i;
            for (i = 1; i <= _ileSal; i++)
            {
                _sale.Add(new Sala(i, 4));
            }
            for (i = 1; i <= 30; i++)
            {
                var th = new Thread(() => _sale.ForEach(x => x.Ogladaj()))
                {
                    Name = $"{i}"
                };
                th.Start();
            }
            Console.ReadKey();
        }
        class Sala
        {
            Semaphore _sem;
            int _index;
            public Sala(int index, int max)
            {
                _index = index;
                _sem = new Semaphore(max, max);
            }
            public void Ogladaj()
            {
                _sem.WaitOne();
                _suma++;
                Console.WriteLine($"{Interlocked.Increment(ref _n),2 }: {Thread.CurrentThread.Name,2} w {_index}");
                Thread.Sleep(500);
                _sem.Release();
                if (_suma == _ileSal)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name,2} koniec");
                }
            }
        }
    }
}
