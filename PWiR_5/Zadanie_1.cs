using System;
using System.Collections.Generic;
using System.Threading;

namespace PWiR_5
{
    public class Zadanie_1
    {
        public static void RUN()
        {
            var fil = new PieciuFilozofow();
            fil.Zacznij();
            Thread.Sleep(10000);
            fil.Zakoncz();
            Console.ReadKey();
        }
        class PieciuFilozofow
        {
            List<Semaphore> widelce = new List<Semaphore>(); // Tablica pięciu semaforów
            List<Thread> filozofowie = new List<Thread>();
            Semaphore lokaj;
            public PieciuFilozofow()
            {
                int i;
                for (i = 0; i < 5; i++)
                {
                    widelce.Add(new Semaphore(1, 1));
                }
                lokaj = new Semaphore(4, 4);
                for (i = 0; i < 5; i++)
                {
                    var f = new Thread(new ParameterizedThreadStart(Filozof));
                    f.Name = $"Filozof {i}";
                    filozofowie.Add(f);
                }
            }
            public void Zacznij()
            {
                for (int i = 0; i < filozofowie.Count; i++)
                {
                    filozofowie[i].Start(i);
                }
            }

            public void Zakoncz()
            {
                foreach (var f in filozofowie)
                {
                    f.Interrupt();
                }
            }
            private void Filozof(object n)
            {
                int i = (int)n;
                try
                {
                    do
                    {
                        Console.WriteLine($"{Thread.CurrentThread.Name} myśli");
                        Thread.Sleep(300);
                        lokaj.WaitOne();
                        widelce[i].WaitOne();
                        widelce[(i + 1) % 5].WaitOne();
                        Console.WriteLine($"{Thread.CurrentThread.Name} je");
                        widelce[(i + 1) % 5].Release();
                        widelce[i].Release();
                        lokaj.Release();
                    } while (true);
                }
                catch (ThreadInterruptedException e)
                {
                }
            }
        }
    }
}
