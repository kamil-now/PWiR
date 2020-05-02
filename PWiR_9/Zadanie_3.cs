using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PWiR_9
{ 
    public class Zadanie_3
    {
        public static void RUN()
        {
            int start = Environment.TickCount;

            Action[] list = new Action[] { () => FindFibbonaciNumber(40), () => FindFibbonaciNumber(40) };

            //list.ToList().ForEach(x => x.Invoke()); // wariant sekwencyjny
            Parallel.Invoke(list);                  // wariant równoległy

            int stop = Environment.TickCount;
            Console.WriteLine($"Czas wykonania {(stop - start).ToString("N0")} ms");
            Console.ReadKey();
        }
        // metoda wyznacza n-tą liczbę ciągu Fibbonaciego
        static void FindFibbonaciNumber(int n) // w tym przypadku nie potrzebujemy wyznaczonej liczby, więc metoda nic nie zwraca
        {
            var count = 0; // licznik ilości wyznaczonych liczb
            var a = 0;
            var b = 1;
            var c = 0;
            while (count < n)
            {
                while (true)
                {
                    if (++c == a + b)
                    {
                        break;
                    }
                }
                a = b;
                b = c;
                count++;
            }
        }
    }
}
