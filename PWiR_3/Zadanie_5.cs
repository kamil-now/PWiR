using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace PWiR_3
{
    public class Zadanie_5
    {
        static readonly object _lck = new object();
        static List<int> _numbers = new List<int>();
        static List<(int number, int position)> _perfectNumbers = new List<(int, int)>();
        static int _i = 0;
        public static void RUN()
        {

            using (var reader = new StreamReader(@"C:\liczby.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    int.TryParse(line, out int result);

                    _numbers.Add(result);
                }
            }
            Thread t1 = new Thread(new ThreadStart(PrintProgress));
            Thread t2 = new Thread(new ThreadStart(Search));

            t1.IsBackground = true;
            t2.IsBackground = true;

            t1.Start();
            t2.Start();

            ConsoleKeyInfo key;
            Console.CursorVisible = false;
            do
            {
                key = Console.ReadKey(true);
            } while (key.Key != ConsoleKey.Escape);

            t1.Abort();
            t2.Abort();
        }
        static void PrintProgress()
        {
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"Postęp: Nr rekordu: {_i} z {_numbers.Count} Procent: {(double)_i / _numbers.Count * 100:f2}%\n");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Szukam liczb doskonałych (ESC - Przerwij)");
                Console.ForegroundColor = ConsoleColor.White;

                lock (_lck)
                {
                    _perfectNumbers.ForEach(x =>
                    {
                        Console.WriteLine($"Liczba {x.number} (na pozycji nr {x.position})");
                    });
                }
                Thread.Sleep(100);
            }
        }
        static void Search()
        {
            for (_i = 0; _i < _numbers.Count; _i++)
            {
                var num = _numbers[_i];
                var factorsSum = 0;
                for (int f = 1; f < num; f++)
                {
                    if (num % f == 0)
                    {
                        factorsSum += f;
                    }
                }
                if (factorsSum == num)
                {
                    lock (_lck)
                    {
                        _perfectNumbers.Add((num, _i));
                    }
                }
            }
        }
    }
}